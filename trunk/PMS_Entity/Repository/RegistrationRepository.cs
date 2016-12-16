using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_Entity.Interface;
using PMS_Entity.Model.Master;

namespace PMS_Entity.Repository
{
    public class RegistrationRepository : IRegistration
    {
        PerformanceManagementDBContext _PMSDBEntities;
        public RegistrationRepository(PerformanceManagementDBContext PMSDBEntities)
        {
            _PMSDBEntities = PMSDBEntities;
        }


        public ClientRegistration ValidateToken(string Token)
        {
            ClientRegistration objcr = new ClientRegistration();

            var accountDetail = from ad in _PMSDBEntities.ClientRegistrations
                                where ad.Token == Token
                                select ad;

            if (accountDetail == null)
            {
                objcr = null;
                return objcr;
            }
            else
            {
                return accountDetail.FirstOrDefault();
            }

        }

        public KeysValues GetEncryptionDecryptionKeys(string UniqueID)
        {
            KeysValues objkv = new KeysValues();

            var KeyDetail = (from ad in _PMSDBEntities.ClientRegistrations
                             where ad.UniqueID == UniqueID
                             select new
                             {
                                 ad.IVKey,
                                 ad.EncryKey
                             }).FirstOrDefault();

            if (KeyDetail == null)
            {
                objkv = null;
            }
            else
            {
                objkv.EncryKey = KeyDetail.EncryKey;
                objkv.IVKey = KeyDetail.IVKey;
            }
            return objkv;
        }
    }
}
