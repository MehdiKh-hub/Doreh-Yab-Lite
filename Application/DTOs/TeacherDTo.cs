using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TeacherDTo
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string? Bio { get; private set; }
        public string? Email { get; private set; }
        public int Rank { get; private set; }
    }
}
