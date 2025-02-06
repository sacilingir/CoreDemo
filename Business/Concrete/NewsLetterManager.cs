using Business.Abstract;
using DataAccess.Abstract;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetterDal _newsletter;

		public NewsLetterManager(INewsLetterDal newsletter)
		{
			_newsletter = newsletter;
		}

		public void AddNewsLetter(NewsLetter newsletter)
		{
			_newsletter.Insert(newsletter);
		}
	}
}
