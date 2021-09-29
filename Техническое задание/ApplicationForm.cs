using System;
using System.Collections.Generic;
using System.Text;

namespace Техническое_задание
{
    class ApplicationForm
    {
        public int Id { get; set; }
        public int Balls { get; set; }
        public int ClientsId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LoanAmount { get; set; }
        public int CreditAmount { get; set; }
        public int CreditStory { get; set; }
        public int CreditDelay { get; set; }
        public string CreditTarget { get; set; }
        public int CreditTerm { get; set; }
    }
}
