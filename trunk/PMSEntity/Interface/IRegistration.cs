using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMSEntity.Model.Master;

namespace PMSEntity.Interface
{
    public interface IRegistration
    {
        ClientRegistration ValidateToken(string Token);
        KeysValues GetEncryptionDecryptionKeys(string UniqueID);
    }
}