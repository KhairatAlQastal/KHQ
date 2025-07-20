using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Domain.Entities
{
    public class FAQ
    {
        public Guid Id { get; set; }
        public string QuestionEn { get; set; }
        public string QuestionAr { get; set; }
        public string AnswerEn { get; set; }
        public string AnswerAr { get; set; }
    }
}
