using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Models
{
    public class Element 
    {
        [Key]
        public int Id { get; set; }
        public string ElementName { get; set; }
        public static Boolean Required { get; set; }
        public static Boolean Conditional { get; set; }
        public static Boolean Repeatable { get; set; }
        public static int DataCategory_Id { get; set; }
        public static string Datatype { get; set; }
        public static int DatatypeSize { get; set; }

        public DataCategory DataCategory { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
