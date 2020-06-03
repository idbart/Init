using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Init_Desktop.Scripts;
using Init_Desktop.Scripts.Interfaces;

namespace Init_Desktop.Models
{
    public class MainModel
    {
        private IDataAccess dataAccess;

        public MainModel(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public List<Template> getTemplatesList()
        {
            return dataAccess.getTemplates();
        }
    }
}
