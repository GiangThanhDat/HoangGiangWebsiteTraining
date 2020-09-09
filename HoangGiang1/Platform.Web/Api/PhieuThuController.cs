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
    [RoutePrefix("api/phieuthu")]
    [Authorize]
    public class PhieuThuController : ApiControllerBase
    {
        IPhieuThuService _phieuThuService;

        public PhieuThuController(ILoiService loiService, IPhieuThuService phieuThuService) : base(loiService)
        {
            this._phieuThuService = phieuThuService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<PhieuThuViewModel> phieuThuVM)
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
        //            foreach (var item in phieuThuVM)
        //            {
        //                var newThongBao = new PhieuThu();
        //                newThongBao.UpdatePhieuThu(item);

        //                _phieuThuService.Add(newThongBao);
        //                _phieuThuService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}


        //[Route("update")]
        //[HttpPut]
        //[AllowAnonymous]
        //public HttpResponseMessage update(HttpRequestMessage request, PhieuThuViewModel phieuThuViewModel)

        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {

        //            var vienchucDb = _phieuThuService.getID(Convert.ToInt32(phieuThuViewModel.ID));

        //            vienchucDb.UpdatePhieuThu(phieuThuViewModel);
        //            _phieuThuService.Update(vienchucDb);
        //            _phieuThuService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, PhieuThuViewModel khachHang)
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
                    var newThongBao = new PhieuThu();
                    newThongBao.UpdatePhieuThu(khachHang);

                    _phieuThuService.Add(newThongBao);
                    _phieuThuService.Save();
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


                var listCategory = _phieuThuService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<PhieuThu>,IEnumerable<PhieuThuViewModel>>(listCategory);
                var b = listCategory.OrderBy(x => x.MaPhieuThu.Length + x.MaPhieuThu);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, b);


                return response;
            });
        }

        [Route("getchitietphieuthu")]
        [HttpGet]
        public HttpResponseMessage getchitietphieuthu(HttpRequestMessage request, string maPT)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _phieuThuService.getchitietphieuthu(maPT);


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


        [Route("getPhieuThu")]
        public HttpResponseMessage getPhieuThu(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _phieuThuService.getPhieuThu(ngaydau, ngaycuoi);


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, PhieuThu phieuThu)
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
                    _phieuThuService.Add(phieuThu);
                    _phieuThuService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PhieuThu phieuThu)
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
                    _phieuThuService.Update(phieuThu);
                    _phieuThuService.Commit();

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
                    _phieuThuService.delete(id);
                    _phieuThuService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
