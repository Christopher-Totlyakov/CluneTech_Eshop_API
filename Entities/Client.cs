namespace Entities;

public class Client
{
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Sex
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Addresses
        /// </summary>
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// Sales
        /// </summary>
        public List<Sale> Sales { get; set; }
}
