using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init_Desktop.Scripts.Interfaces
{
    public interface IDataAccess
    {
        List<Template> getTemplates();
        bool createTemplate(string name);
        void deleteTemplate(string name);
    }
}
