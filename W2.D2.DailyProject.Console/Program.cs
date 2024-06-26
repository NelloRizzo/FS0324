using W2.D2.DailyProject.Business.Models;
using W2.D2.DailyProject.Business.Services;

internal class Program
{
    private static readonly ICurriculumService curriculumService = new ConstCurriculumService();

    private static void Print(List<Study> studies) {
        foreach (var study in studies) {
            Console.WriteLine("Istituto: {0}", study.Institute);
            if (!string.IsNullOrEmpty(study.Qualification))
                Console.WriteLine("Qualifica: {0}", study.Qualification);
            if (!string.IsNullOrEmpty(study.Kind))
                Console.WriteLine("Tipo: {0}", study.Kind);
            Console.WriteLine("Dal {0} al {1}", study.From, study.To);
            Console.WriteLine();
        }
    }

    private static void Print(List<Experience> experiences) {
        foreach (var experience in experiences) {
            Console.WriteLine("Presso: {0}", experience.Company);
            Console.WriteLine("Tipo di lavoro: {0}", experience.JobTitle);
            Console.WriteLine("Qualifica: {0}", experience.JobDescription);
            Console.WriteLine("Dal {0} al {1}", experience.From, experience.To);
            Console.WriteLine();
        }
    }
    private static void Print(Curriculum cv) {
        Console.WriteLine("+++++ Dati Personali +++++");
        Console.WriteLine("Nome: {0}", cv.PersonalData.FirstName);
        Console.WriteLine("Cognome: {0}", cv.PersonalData.LastName);
        Console.WriteLine("Email: {0}", cv.PersonalData.Email);
        Console.WriteLine("Telefono: {0}", cv.PersonalData.Phone);
        Console.WriteLine();

        Console.WriteLine("+++++ Studi e Formazione +++++");
        Print(cv.Studies.OrderByDescending(s => s.To).ToList());

        Console.WriteLine("+++++ Esperienze Professionali +++++");
        Print(cv.Experiences.OrderByDescending(e => e.To).ToList());
    }
    private static void Main(string[] args) {
        Print(curriculumService.GetCurriculum());
    }
}