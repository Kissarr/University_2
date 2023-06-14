using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab_4.Models;
using Lab_4.Context;
using Newtonsoft.Json;

namespace Lab_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public ExamController(IWebHostEnvironment environment)
        {
            _webHostEnvironment = environment;
        }


        [HttpPost("/add")]
        public string AddStudentExam(Exam exam)
        {
            if (exam.Mounth <13 && exam.Mounth > 0 && exam.Grade < 6 && exam.Grade > 0 && exam.Day < 32 && exam.Day > 0)
            {
                Context.Context context = new Context.Context();
                context.Add(exam);
                return "add";
            }
            else
                return "invalid inserted data";
        }
        [HttpPost("/change")]
        public string ChangeStudentExam(Exam exam)
        {
            if (exam.Mounth < 13 && exam.Mounth > 0 && exam.Grade < 6 && exam.Grade > 0 && exam.Day <32 && exam.Day > 0)
            {
                Context.Context context = new Context.Context();
                context.Change(exam);
                return "change";
            }
            else
                return "invalid inserted data";
        }

        [HttpPost("/delete")]
        public string Delete(Delete delete)
        {
            Context.Context context = new Context.Context();
            string result =context.Delete(delete);
            return result;
        }

        [HttpGet("/show")]
        public IActionResult ShowExam()
        {
            List<Exam> exams = new List<Exam>();
            Context.Context context = new Context.Context();
            exams = context.Show();
            foreach (Exam exam in exams)
                Console.WriteLine(exam.Questions[0]);
            return new JsonResult(exams);
        }

        [HttpPost("/find_by_id")]
        public Exam Find(Delete delete)
        {
            Exam result = new Exam();
            List<Exam> exams = new List<Exam>();
            Context.Context context = new Context.Context();
            exams = context.Find(delete);
            if(exams.Count !=0)
            {
                result.Id = exams[0].Id;

                result.Trial_name = exams[0].Trial_name;

                result.Firstname = exams[0].Firstname;
                result.Middlename = exams[0].Middlename;
                result.Lastname = exams[0].Lastname;

                result.Speciality = exams[0].Speciality;
                result.Number = exams[0].Number;

                result.Grade = exams[0].Grade;

                result.Year = exams[0].Year;
                result.Day = exams[0].Day;
                result.Mounth = exams[0].Mounth;

                List<string> questions = new List<string>();
                foreach (Exam exam in exams)
                {
                    questions.Add(exam.Questions[0]);
                }
                result.Questions = questions;
            }
            return result;
        }
    }
}
