using Nagarro.BookReading.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nagarro.BookReading.Foundation.OberverPattern
{
    public class Subject : ISubject
    {
        List<INotify> observerList = new List<INotify>();
        private int flag;
        public int Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
                
                NotifyUsers(flag);
            }
        }
        public void Post(INotify comment)
        {
            observerList.Add(comment);
        }
      
        public void NotifyUsers(int i)
        {
            foreach (INotify comment in observerList)
            {
                comment.Update(i);
            }
        }
    }
}


