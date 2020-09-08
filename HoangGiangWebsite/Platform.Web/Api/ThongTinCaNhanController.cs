using AutoMapper;
using Platform.Model;
using Platform.Service;
using Platform.Web.infratructure.core;
using Platform.Web.infratructure.extensions;
using Platform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace Platform.Web.Api
{
    [RoutePrefix("api/thongtincanhan")]
    [Authorize]
    public class ThongTinCaNhanController : ApiControllerBase
    {
        IThongTinCaNhanService _thongTinCaNhan;
        public ThongTinCaNhanController(ILoiService loiService, IThongTinCaNhanService thongTinCaNhanService) : base(loiService)
        {
            this._thongTinCaNhan = thongTinCaNhanService;
        }
       
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _thongTinCaNhan.GetAll();
                var listHocPhiVm = Mapper.Map<List<ThongTinCaNhanViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listHocPhiVm);


                return response;
            });
        }
        [Route("GetLyLich")]
        [HttpGet]

        public HttpResponseMessage GetLyLich(HttpRequestMessage request, string msvc)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _thongTinCaNhan.GetLyLich(msvc);

                var responseData = Mapper.Map<ThongTinCaNhan, ThongTinCaNhanViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Put(HttpRequestMessage request, ThongTinCaNhanViewModel vienChucVM)
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

                    var sinhVienDb = _thongTinCaNhan.GetLyLich(vienChucVM.MaSoVC);
                  
                    sinhVienDb.UpdateThongTinCaNhan(vienChucVM);
                   


                    _thongTinCaNhan.Update(sinhVienDb);
                    _thongTinCaNhan.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }


       


        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage CreateVienChuc(HttpRequestMessage request, ThongTinCaNhanViewModel phongHocVM)
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

                    var newPhongHoc = new ThongTinCaNhan();
                    newPhongHoc.UpdateThongTinCaNhan(phongHocVM);
                   
                    _thongTinCaNhan.Add(newPhongHoc);
                    _thongTinCaNhan.Save();




                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }



        
    }
}
