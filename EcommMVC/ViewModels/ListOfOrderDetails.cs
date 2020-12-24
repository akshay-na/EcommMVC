using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommMVC.Models;

namespace EcommMVC.ViewModels
{
    public class ListOfOrderDetails
    {

        public List<OrderDetails> OrderDetail { get; set; }

        public ListOfOrderDetails(List<OrderDetails> orderDetail)
        {
            this.OrderDetail = orderDetail;
        }

        public ListOfOrderDetails()
        {
            
        }


    }
    
}