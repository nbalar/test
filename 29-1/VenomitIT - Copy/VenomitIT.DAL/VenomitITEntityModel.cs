using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenomitIT.DAL
{
  public  class VenomitITEntityModel
    {
        private static cms_venomitEntities _entityModel;
        static VenomitITEntityModel()
        {
            _entityModel = new cms_venomitEntities(DALConfigHelper.ConnectionString);            
        }

        public static cms_venomitEntities EntityModel
        {
            get
            {
                if (_entityModel.Connection.State == System.Data.ConnectionState.Closed)
                {
                    _entityModel.Connection.Open();
                }
                return _entityModel;
            }
            set
            {
                _entityModel = value;
            }
        }
    }
}
