namespace Entities;

public class Account
{
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password Hash
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Client
        /// </summary>
        public Client Client { get; set; }
}
