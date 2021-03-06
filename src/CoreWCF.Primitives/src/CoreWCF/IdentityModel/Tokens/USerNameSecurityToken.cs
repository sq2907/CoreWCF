﻿using CoreWCF.Security;
using System;
using System.Collections.ObjectModel;

namespace CoreWCF.IdentityModel.Tokens
{
    internal class USerNameSecurityToken : SecurityToken
    {
        string id;
        string password;
        string userName;
        DateTime effectiveTime;

        public USerNameSecurityToken(string userName, string password)
            : this(userName, password, SecurityUniqueId.Create().Value)
        {
        }

        public USerNameSecurityToken(string userName, string password, string id)
        {
            if (userName == null)
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull(nameof(userName));
            if (userName == string.Empty)
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(SR.UserNameCannotBeEmpty);

            this.userName = userName;
            this.password = password;
            this.id = id;
            effectiveTime = DateTime.UtcNow;
        }

        public override string Id
        {
            get { return id; }
        }

        public override ReadOnlyCollection<SecurityKey> SecurityKeys
        {
            get { return EmptyReadOnlyCollection<SecurityKey>.Instance; }
        }

        public override DateTime ValidFrom
        {
            get { return effectiveTime; }
        }

        public override DateTime ValidTo
        {
            // Never expire
            get { return SecurityUtils.MaxUtcDateTime; }
        }

        public string UserName
        {
            get { return userName; }
        }

        public string Password
        {
            get { return password; }
        }
    }

}
