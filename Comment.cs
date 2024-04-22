using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lorry_db_L77
{
    public class Comment
    {
        public int Id_comment { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public int Fk_id_customer { get; set; }
        public int Fk_id_flight { get; set; }

        public Comment(int id, string text, int grade, int fk_c, int fk_f)
        {
            Id_comment = id;
            Text = text;
            Grade = grade;
            Fk_id_customer = fk_c;
            Fk_id_flight = fk_f;
        }
    }
}
