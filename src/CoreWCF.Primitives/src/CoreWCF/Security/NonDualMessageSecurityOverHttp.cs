namespace CoreWCF
{
    public sealed class NonDualMessageSecurityOverHttp : MessageSecurityOverHttp
    {
        internal const bool DefaultEstablishSecurityContext = true;

        bool establishSecurityContext;

        public NonDualMessageSecurityOverHttp()
            : base()
        {
            this.establishSecurityContext = DefaultEstablishSecurityContext;
        }

        public bool EstablishSecurityContext
        {
            get
            {
                return this.establishSecurityContext;
            }
            set
            {
                this.establishSecurityContext = value;
            }
        }

        protected override bool IsSecureConversationEnabled()
        {
            return this.establishSecurityContext;
        }
    }
}
