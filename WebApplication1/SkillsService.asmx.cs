using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Neo4jClient;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for SkillsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SkillsService : System.Web.Services.WebService
    {

        GraphClient graphClient;
        public SkillsService()
        {
            graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "skills");
            graphClient.Connect();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string createProject(string projectName)
        {
            string result = "";

            if (projectName != "")
            {
                Project newProject = new Project(projectName);
                graphClient.Cypher
                    .Merge("(proj:Project {name: {name}})")
                    .OnCreate()
                    .Set("proj = {newProject}")
                    .WithParams(new
                    {
                        name = newProject.getName(),
                        newProject
                    })
                    .ExecuteWithoutResults();
                result = "The project has been created.";
                return result;
            }
            else
            {
                result = "The project need a name.";
                return result;
            }
        }

        [WebMethod]
        public string createEmployee(string employeeName)
        {
            string result = "";

            if (employeeName != "")
            {
                Employee newEmployee = new Employee(employeeName);
                graphClient.Cypher
                    .Merge("(emp:Employee {name: {name}})")
                    .OnCreate()
                    .Set("emp = {newEmployee}")
                    .WithParams(new
                    {
                        name = newEmployee.getName(),
                        newEmployee
                    })
                    .ExecuteWithoutResults();
                result = "The employee has been created.";
                return result;
            }
            else
            {
                result = "The employee need a name.";
                return result;
            }
        }

        [WebMethod]
        public string createSkill(string skillName)
        {
            string result = "";

            if (skillName != "")
            {
                Skill newSkill = new Skill(skillName);
                graphClient.Cypher
                    .Merge("(skill:Skill {name: {name}})")
                    .OnCreate()
                    .Set("skill = {newSkill}")
                    .WithParams(new
                    {
                        name = newSkill.getName(),
                        newSkill
                    })
                    .ExecuteWithoutResults();
                result = "The skill has been created.";
                return result;
            }
            else
            {
                result = "The skill need a name.";
                return result;
            }
        }

        [WebMethod]
        public string read(string name, string element)
        {
            string result = "";

            if (name != "")
            {
                Skill newSkill = new Skill(name);
                graphClient.Cypher
                    .Merge("(skill:Skill {name: {name}})")
                    .OnCreate()
                    .Set("skill = {newSkill}")
                    .WithParams(new
                    {
                        name = newSkill.getName(),
                        newSkill
                    })
                    .ExecuteWithoutResults();
                result = "The skill has been created.";
            }
            else
            {
                result = "The skill doesn't exist.";
            }

            return result;
        }

        [WebMethod]
        public string update(string name, string parent)
        {
            string result = "";
            if (name != "" && parent != "")
            {
                graphClient.Cypher
                 .Match("(elemA), (elemB)")
                 .Where("elemA.name = {nameA}")
                 .WithParam("nameA", name)
                 .AndWhere("elemB.name = {nameB}")
                 .WithParam("nameB", parent)
                 .Create("(elemA)-[:DERIVED_FROM]->(elemB)")
                 .ExecuteWithoutResults();
            }
            return result;
        }

        [WebMethod]
        public string delete(string name)
        {
            string result = "";
            //string min = "";
            //string label = "";

            //if(element == "project")
            //{

            //    min = "proj";
            //    label = "Project";

            //} else if(element == "employee")
            //{

            //    min = "emp";
            //    label = "Employee";

            //}
            //else if(element == "skill")
            //{

            //    min = "skill";
            //    label = "Skill";

            //}

            if (name != "")
            {
                graphClient.Cypher
                    .OptionalMatch("(n)")
                    .Where("n.name = {name}")
                    .WithParam("name", name)
                    .DetachDelete("n")
                    .ExecuteWithoutResults();

                result = "The element has been created.";
            }

            return result;
        }

        public class Project
        {
            public string name;

            public Project(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return name;
            }

            public void setName(string name)
            {
                this.name = name;
            }
        }

        public class Employee
        {
            public string name;

            public Employee(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return name;
            }

            public void setName(string name)
            {
                this.name = name;
            }
        }

        public class Skill
        {
            public string name;

            public Skill(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return name;
            }

            public void setName(string name)
            {
                this.name = name;
            }
        }
    }
}
