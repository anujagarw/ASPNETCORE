using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Paging
{
    public class PagingList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PagingList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public int TotalPageNo
        {
            get
            {
                return TotalPages;
            }
        }

        public static PagingList<T> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();

            /*
             Where the Take() method, returns a sequence containing the first n elements of the target sequence, 
             the Skip() method "skips" over the first n elements in the sequence and returns a new sequence containing the remaining elements 
                after the first n elements.
             */
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PagingList<T>(items, count, pageIndex, pageSize);
        }
    }
}
