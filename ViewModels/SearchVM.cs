using System;
namespace IndyBooks.ViewModels
{
    public class SearchVM
    {
        public String Title { get; set; }

        //Properties needed for searching
        //TODO : Notice how the ViewModel doesn't need any changes even when
        //        the entity changes since it only deals with the Search view

        public String Name { get; set; }
        public String SKU { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public Boolean Sale { get; set; }

    }
}
