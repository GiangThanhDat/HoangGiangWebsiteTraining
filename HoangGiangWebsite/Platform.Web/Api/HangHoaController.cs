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
    [RoutePrefix("api/hangHoa")]
    [Authorize]
    public class HangHoaController : ApiControllerBase
    {
        IHangHoaService _hangHoaService;
        ITinhChatHangHoaService _tinhChatHangHoaService;
        INhomHangHoaService _nhomHangHoaService;
        IDonViTinhService _donViTinhService;
        IHangHoa_DonViTinhService _hangHoa_DonViTinhService;

        public HangHoaController(ILoiService loiService, IHangHoaService hangHoaService, ITinhChatHangHoaService tinhChatHangHoaService, INhomHangHoaService nhomHangHoaService, IDonViTinhService donViTinhService, IHangHoa_DonViTinhService hangHoa_DonViTinhService) : base(loiService)
        {
            this._hangHoaService = hangHoaService;
            this._tinhChatHangHoaService = tinhChatHangHoaService;
            this._nhomHangHoaService = nhomHangHoaService;
            this._donViTinhService = donViTinhService;
            this._hangHoa_DonViTinhService = hangHoa_DonViTinhService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<HangHoaViewModel> hangHoaVM)
        //{


        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            foreach (var item in hangHoaVM)
        //            {
        //                var newThongBao = new HangHoa();
        //                newThongBao.UpdateHangHoa(item);

        //                _hangHoaService.Add(newThongBao);
        //                _hangHoaService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}


        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, HangHoaViewModel hangHoaViewModel)

        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {

                    var vienchucDb = _hangHoaService.GetByID(hangHoaViewModel.MaHang);

                    vienchucDb.UpdateHangHhoa(hangHoaViewModel);
                    vienchucDb.NgaySua = DateTime.Now;
                    _hangHoaService.Update(vienchucDb);
                    _hangHoaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        [Route("getallhanghoa")]
        [HttpGet]
        public HttpResponseMessage getallhanghoa(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                var  listCategory = _hangHoaService.GetAll();
                 var hanghoa = Mapper.Map<IEnumerable<HangHoa>, IEnumerable<HangHoa>>(listCategory);
                foreach (var item in hanghoa)
                {
                    item.getdvt = _hangHoa_DonViTinhService.getdvt(item.MaHang);
                }
               
                totalRow = hanghoa.Count();
                var query = hanghoa.OrderByDescending(x => x.MaHang).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<HangHoa>, IEnumerable<HangHoa>>(query);

                var PaginationSet = new PaginationSet<HangHoa>()
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








        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, HangHoaViewModel khachHang)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newThongBao = new HangHoa();
                    newThongBao.UpdateHangHhoa(khachHang);

                    _hangHoaService.Add(newThongBao);
                    _hangHoaService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _hangHoaService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<HangHoa>,IEnumerable<HangHoaViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getbyid")]
        [HttpGet]
        public HttpResponseMessage getbyid(HttpRequestMessage request,string id)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _hangHoaService.GetByID(id);
                var hangHoa = Mapper.Map<HangHoa, HangHoaViewModel>(listCategory);
                if (hangHoa!=null)
                {
                    var tinhchat = _tinhChatHangHoaService.GetByID(listCategory.MaTinhChat);
                    hangHoa.TinhChatHangHoa = Mapper.Map<TinhChatHangHoa, TinhChatHangHoaViewModel>(tinhchat);
                    var nhomhh = _nhomHangHoaService.GetByID(listCategory.MaNhomHH);
                    hangHoa.NhomHangHoa = Mapper.Map<NhomHangHoa, NhomHangHoaViewModel>(nhomhh);
                    hangHoa.getdvt = _hangHoa_DonViTinhService.getdvt(listCategory.MaHang);
                }



                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, hangHoa);


                return response;
            });
        }

        [Route("getdvt")]
        [HttpGet]
        public HttpResponseMessage getdvt(HttpRequestMessage request, int madvt)
        {
            return CreateHttpResponse(request, () =>
            {

                      var tendvt = _donViTinhService.GetByID(madvt);
                      var  hangHoa = Mapper.Map<DonViTinh, DonViTinhViewModel>(tendvt);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, hangHoa);
                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, HangHoa hangHoa)
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
                    _hangHoaService.Add(hangHoa);
                    _hangHoaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, HangHoa hangHoa)
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
                    _hangHoaService.Update(hangHoa);
                    _hangHoaService.Commit();

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
                    _hangHoaService.delete(id);
                    _hangHoaService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
