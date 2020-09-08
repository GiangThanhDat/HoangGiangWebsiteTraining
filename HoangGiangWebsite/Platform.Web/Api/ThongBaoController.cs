using AutoMapper;
using Newtonsoft.Json.Linq;
using Platform.Model;
using Platform.Service;
using Platform.Web.infratructure.core;
using Platform.Web.infratructure.extensions;
using Platform.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Platform.Web.Infrastructure.Core;

namespace Platform.Web.Api
{
    [RoutePrefix("api/ThongBao")]
    [Authorize]
    public class ThongBaoController : ApiControllerBase
    {
        IThongBaoService _thongBaoService;

        public ThongBaoController(ILoiService loiService, IThongBaoService thongBaoService) : base(loiService)
        {
            this._thongBaoService = thongBaoService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ThongBaoViewModel> thongBaoVm)
        {


            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    foreach (var item in thongBaoVm)
                    {
                        var newThongBao = new ThongBao();
                        newThongBao.UpdateThongBao(item);

                        _thongBaoService.Add(newThongBao);
                        _thongBaoService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        public HttpResponseMessage Create(HttpRequestMessage request, ThongBao thongBao)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _thongBaoService.Add(thongBao);
                    _thongBaoService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, thongBao);
                }
                return response;
            });

        }
		 [Route("chitietTB")]
        [HttpGet]
        public HttpResponseMessage chitietTB(HttpRequestMessage request, int MaSoTB)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _thongBaoService.chitietTB(MaSoTB);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _thongBaoService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

		[Route("getTB")]				
        public HttpResponseMessage GetTB(HttpRequestMessage request, int page, string mssv, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                IEnumerable<ThongBao> thongBao = _thongBaoService.GetThongBao(mssv);
                totalRow = thongBao.Count();
                var query = thongBao.OrderByDescending(x => x.MaSoTB).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<ThongBao>, IEnumerable<ThongBaoViewModel>>(query);

                var PaginationSet = new PaginationSet<ThongBaoViewModel>()
                {

                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,/*tong so bai ghi*/
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),/*tong số trang*/



                };


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, PaginationSet);


                return response;
            });
        }
        public HttpResponseMessage Post(HttpRequestMessage request, ThongBao thongBao)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _thongBaoService.Add(thongBao);
                    _thongBaoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ThongBao thongBao)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _thongBaoService.Update(thongBao);
                    _thongBaoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _thongBaoService.delete(id);
                    _thongBaoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
