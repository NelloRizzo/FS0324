using W2.D2.DailyProject.Business.Models;

namespace W2.D2.DailyProject.Business.Services
{
    public class ConstCurriculumService : ICurriculumService
    {
        private readonly Curriculum cv = new Curriculum {
            PersonalData = new PersonalData {
                Email = "archimede@paperopoli.com",
                FirstName = "Archimede",
                LastName = "Pitagorico",
                Phone = "31415926"
            },
            Experiences = [new Experience { Company = "Archimede & Edi Inc.", JobDescription = "Inventore", JobTitle = "Dott.", Tasks = "Invenzioni di ogni tipo", From = new DateOnly(1990, 1, 1), To = new DateOnly(1991, 1, 1) }],
            Studies = [
                new Study { Institute="Istituto professionale Paperopoli",
                    Kind="Istruzione superiore", Qualification="Diploma", From = new DateOnly(1970, 1,1), To=new DateOnly(1975, 5, 31)},
                new Study{ Institute ="Libera Università di Paperopoli", Kind="Università", Qualification="Laurea", From = new DateOnly(1975, 10, 1), To=new DateOnly(1978, 5, 31)}]
        };
        public Curriculum GetCurriculum() => cv;
    }
}
