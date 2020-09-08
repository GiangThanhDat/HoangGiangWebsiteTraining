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
    [RoutePrefix("api/nhanvien")]
    //[Authorize]
    public class NhanVienController : ApiControllerBase
    {
        INhanVienService _nhanVien;
        public NhanVienController(ILoiService loiService, INhanVienService nhanVienService) : base(loiService)
        {
            this._nhanVien = nhanVienService;
        }
       
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _nhanVien.GetAll();
                //var listHocPhiVm = Mapper.Map<List<NhanVienViewModel>>(listCategory);
                var b = listCategory.OrderBy(x => x.MaSoNhanVien);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, b);


                return response;
            });
        }

        [Route("search")]
        [HttpGet]
        public HttpResponseMessage search(HttpRequestMessage request,string keyword)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _nhanVien.search(keyword);
                //var listHocPhiVm = Mapper.Map<List<NhanVienViewModel>>(listCategory);
              

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getnhanvien")]
        public HttpResponseMessage getnhanvien(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _nhanVien.getnhanvien();

                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }
        [Route("getnhanVien")]
        [HttpGet]

        public HttpResponseMessage getnhanVien(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _nhanVien.nhanVien(msnv);
                var responseData = Mapper.Map<NhanVien, NhanVien>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getbymsnv")]
        public HttpResponseMessage getbymsnv(HttpRequestMessage request,string msnv)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _nhanVien.getbymsnv(msnv);
                //var listHocPhiVm = Mapper.Map<List<NhanVienViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaSoNhanVien);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Put(HttpRequestMessage request, NhanVienViewModel vienChucVM)
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

                    var sinhVienDb = _nhanVien.GetLyLich(vienChucVM.MaSoNhanVien);
                  
                    sinhVienDb.UpdateNhanVien(vienChucVM);
                   


                    _nhanVien.Update(sinhVienDb);
                    _nhanVien.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("getchucvu")]
        public HttpResponseMessage getchucvu(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _nhanVien.getchucvu(msnv);

                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }




        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage CreateVienChuc(HttpRequestMessage request, NhanVienViewModel phongHocVM)
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

                    var newPhongHoc = new NhanVien();
                    newPhongHoc.UpdateNhanVien(phongHocVM);
                   
                    _nhanVien.Add(newPhongHoc);
                    _nhanVien.Save();




                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }



        
    }
}
