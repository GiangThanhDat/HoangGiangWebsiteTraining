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
    [RoutePrefix("api/chitietchungtubanhang")]
   [Authorize]
    public class ChiTietChungTuBanHangController : ApiControllerBase
    {
        IChiTietChungTuBanHangService _chiTietChungTuBanHangService;
        IDonViTinhService _donViTinhService;

        public ChiTietChungTuBanHangController(ILoiService loiService, IChiTietChungTuBanHangService chiTietChungTuBanHangService, IDonViTinhService donViTinhService) : base(loiService)
        {
            this._chiTietChungTuBanHangService = chiTietChungTuBanHangService;
            this._donViTinhService = donViTinhService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietChungTuBanHangViewModel> chiTietChungTuBanHangVM)
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
        //            foreach (var item in chiTietChungTuBanHangVM)
        //            {
        //                var newThongBao = new ChiTietChungTuBanHang();
        //                newThongBao.UpdateChiTietChungTuBanHang(item);

        //                _chiTietChungTuBanHangService.Add(newThongBao);
        //                _chiTietChungTuBanHangService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietChungTuBanHangViewModel chiTietChungTuBanHangViewModel)

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

        //            var vienchucDb = _chiTietChungTuBanHangService.getID(Convert.ToInt32(chiTietChungTuBanHangViewModel.ID));

        //            vienchucDb.UpdateChiTietChungTuBanHang(chiTietChungTuBanHangViewModel);
        //            _chiTietChungTuBanHangService.Update(vienchucDb);
        //            _chiTietChungTuBanHangService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietChungTuBanHangViewModel> chiTietChungTuBanHangVM)
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
                    foreach (var item in chiTietChungTuBanHangVM)
                    {
                        var newThongBao = new ChiTietChungTuBanHang();
                        newThongBao.UpdateChiTietChungTuBanHang(item);

                        _chiTietChungTuBanHangService.Add(newThongBao);
                        _chiTietChungTuBanHangService.Save();
                    }
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


                var listCategory = _chiTietChungTuBanHangService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<ChiTietChungTuBanHang>,IEnumerable<ChiTietChungTuBanHangViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietChungTuBanHang.Length + x.MaChiTietChungTuBanHang);
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
                var listCategory = _chiTietChungTuBanHangService.getbyid(id);
               HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }
        [Route("getchitietchungtubanhang")]
        public HttpResponseMessage getchitietchungtubanhang(HttpRequestMessage request, string MaChungTuBanHang)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietChungTuBanHangService.getchitietchungtubanhang(MaChungTuBanHang);
                var map = Mapper.Map<IEnumerable<getchitietchungtubanhang>>(listCategory);

                foreach (var item in map)
                {
                    item.getdvt = _donViTinhService.GetByID(item.MaDonViTinh);
                    item.getdvt = Mapper.Map<DonViTinh>(item.getdvt);

                }
                


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, map);


                return response;
            });
        }

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietChungTuBanHang chiTietChungTuBanHang)
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
                    _chiTietChungTuBanHangService.Add(chiTietChungTuBanHang);
                    _chiTietChungTuBanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietChungTuBanHang chiTietChungTuBanHang)
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
                    _chiTietChungTuBanHangService.Update(chiTietChungTuBanHang);
                    _chiTietChungTuBanHangService.Commit();

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
                    _chiTietChungTuBanHangService.delete(id);
                    _chiTietChungTuBanHangService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("getthongkechitiet")]
        [HttpGet]
        public HttpResponseMessage getthongkechitiet(HttpRequestMessage request, DateTime ngaydau,DateTime ngaycuoi, bool dathaydoi,string orderby, int machucvu, string manv, string macoso)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _chiTietChungTuBanHangService.thongkechitietchungtubanhang(ngaydau,ngaycuoi,dathaydoi);
                var map1 = Mapper.Map<IEnumerable<thongketop10>>(listCategory);

                var filter = from s in listCategory
                             group s by new { s.TenDonViTinh, s.MaHang,s.MaSoNhanVien } into g
                             select new thongketop10
                             {
                                 TenDonViTinh = g.Key.TenDonViTinh,
                                 MaHang = g.Key.MaHang,
                                 TenHang=g.First().TenHang,
                                 MaSoNhanVien=g.Key.MaSoNhanVien,
                                 HoVaTen=g.First().HoVaTen,
                                 MaCoSo=g.First().MaCoSo,
                                 TenCoSo=g.First().TenCoSo,

                                 SoLuong = g.Sum(s => s.SoLuong),
                                 ThanhTien = g.Sum(s => s.ThanhTien)
                             };

                IEnumerable<thongketop10> filteredValues = new List<thongketop10>();
                var map123 = Mapper.Map<IEnumerable<thongketop10>>(filter);

                if (machucvu == 59)
                {
                    filteredValues = filter.Where(x => x.MaSoNhanVien == manv);

                }
                else if (78 <= machucvu && machucvu <= 79)
                {
                    var a = filter.Where(x => x.MaCoSo == macoso);
                    if (manv == null)
                    {
                        filteredValues = a;
                    }
                    else
                    {
                        filteredValues = a.Where(x => x.MaSoNhanVien == manv);
                    }
                }
                else if (98 <= machucvu && machucvu <= 99)
                {

                    if (macoso == null)
                    {
                        filteredValues = filter;
                    }
                    else
                    {
                        filteredValues = filter.Where(x => x.MaCoSo == macoso);
                    }
                }

                var map12 = Mapper.Map<IEnumerable<thongketop10>>(filteredValues);



                var loc = filteredValues.OrderByDescending(x => x.ThanhTien).Take(10);





                if (orderby=="doanhthu")
                {
                     loc = filteredValues.OrderByDescending(x => x.ThanhTien).ThenByDescending(x=>x.SoLuong).Take(10);
                }
                else if (orderby=="soluong")
                {
                     loc = filteredValues.OrderByDescending(x => x.SoLuong).ThenByDescending(x=>x.ThanhTien).Take(10);
                }

               




                var map = Mapper.Map<IEnumerable<thongketop10>>(loc);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, map);
                return response;
            });
        }


        [Route("getalll")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage getall(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _chiTietChungTuBanHangService.GetAll();
                
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }



    }
}
