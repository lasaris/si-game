using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class SearchingMinigameDto : ComponentBaseDto
    {
        public string Solution { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public IEnumerable<WordDto> Words { get; set; } = new List<WordDto>();
    }
}