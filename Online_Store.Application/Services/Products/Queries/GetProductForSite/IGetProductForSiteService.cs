using Microsoft.EntityFrameworkCore;
using Online_Store.Application.Interfaces.Contexts;
using Online_Store.Common;
using Online_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Application.Services.Products.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        ResultDto<ResultProductForSiteDto> Execute(Ordering ordering, string SearchKey, int Page, int pageSize, long? CatId);
    }

    public enum Ordering
    {

        NotOrder = 0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,
        /// <summary>
        /// پرفروشترین
        /// </summary>
        Bestselling = 2,
        /// <summary>
        /// محبوبترین
        /// </summary>
        MostPopular = 3,
        /// <summary>
        /// جدیدترین
        /// </summary>
        theNewest = 4,
        /// <summary>
        /// ارزانترین
        /// </summary>
        Cheapest = 5,
        /// <summary>
        /// گرانترین
        /// </summary>
        theMostExpensive = 6
    }
}
