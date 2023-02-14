using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Organization organization = new Organization { Name="APL"};
            Trainer trainer = new Trainer();
            trainer.Organization= organization;
            Training training = new Training();
            training.Trainer = trainer;
            System.Console.WriteLine(training.GetTrainingOrganizationName());

            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);
            Console.WriteLine($"No. of trainees: {training.GetNumOfTrainees()}");

            Unit u1 = new Unit { Duration = 120};
            Unit u2 = new Unit { Duration = 150};
            Unit u3 = new Unit { Duration = 60 };
            Unit u4 = new Unit { Duration = 120 };
            Unit u5 = new Unit { Duration = 150 };
            Unit u6 = new Unit { Duration = 60 };

            Module m1 = new Module();
            m1.Units.Add(u1);
            m1.Units.Add(u2);
            m1.Units.Add(u3);

            Module m2 = new Module();
            m2.Units.Add(u4);
            m2.Units.Add(u5);
            m2.Units.Add(u6);

            Course course = new Course();
            
            course.Modules.Add(m1);
            course.Modules.Add(m2);

            training.Course = course;


            Console.WriteLine($"Training Duration: {training.GetTrainingDurationInHrs()}");
        }
    }

    class Organization
    {
        public string Name { get; set; }
    }

    class Trainer
    {
        public Organization Organization{ get; set; } //Trainer HAS-A organization.

        //Trainer has many trainees
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        //Trainer has many Trainings
        public List<Training> Training { get; set; } = new List<Training>();

    }

    class Trainee
    {
        public Trainer Trainer { get; set; } //Trainee has one Trainer

        //Trainee has many Trainings
        public List<Training> Training { get; set; } = new List<Training> ();
    }

    class Training
    {
        //Training has one Trainer
        public Trainer Trainer { get; set; }
        //Training has many Trainees
        public List<Trainee> Trainees { get; set;} = new List<Trainee>();

        //Training has one Course
        public Course Course { get; set; }

        public string GetTrainingOrganizationName()
        {
            return Trainer.Organization.Name;
        }

        public int GetNumOfTrainees()
        {
            return Trainees.Count;
        }

        public int GetTrainingDurationInHrs()
        {
            int totalDuration = 0;
            //calculate duration
            
            //for each module
            foreach (Module module in Course.Modules)
            {
                //for each Module iterate unit
                foreach(Unit unit in module.Units)
                {
                    totalDuration += unit.Duration;
                }

            }
            return totalDuration;
        }
    }

    class Course
    {
        //Course has many trainings
        public List<Training> Trainings { get; set; } = new List<Training>();

        // Course has many modules

        public List<Module> Modules { get; set; } = new List<Module>();
    }
    class Module
    {
        //Module has many Units
        public List<Unit> Units { get; set; } = new List<Unit>();

    }

    class Unit 
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();

        
    }
    class Topic 
    {
        
    }

}
