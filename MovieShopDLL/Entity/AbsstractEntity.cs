using System.ComponentModel.DataAnnotations;

namespace MovieShopDLL.Entity
{
    public  abstract class AbsstractEntity
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
    }
}
