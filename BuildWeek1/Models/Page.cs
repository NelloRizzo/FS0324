namespace BuildWeek1.Models
{
    public class Pager
    {
        public string Action { get; set; } = string.Empty;
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => TotalRecords / PageSize - 1;
        public int TotalRecords { get; set; }
        public bool IsFirst => PageIndex == 0;
        public bool IsLast => PageIndex == TotalPages - 1;
    }
    public class Page<E>
    {
        public IEnumerable<E> Items { get; set; } = [];
        public Pager Pager { get; set; } = new();
    }

}
