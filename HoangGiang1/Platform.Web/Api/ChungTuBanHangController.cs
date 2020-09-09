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
    [RoutePrefix("api/chungtubanhang")]
    [Authorize]
    public class ChungTuBanHangController : ApiControllerBase
    {
        IChungTuBanHangService _chungTuBanHanggService;
        IKhachHangService _khachHangService;
        INhanVienService _nhanVienService;
        ICoSoService _coSoService;
        IHangHoaService _hangHoaService;
        IPhieuNhapKhoService _phieuNhapKhoService;

        public ChungTuBanHangController(ILoiService loiService, IChungTuBanHangService chungTuBanHanggService, IKhachHangService khachHangService, INhanVienService nhanVienService, ICoSoService coSoService, IHangHoaService hangHoaService, IPhieuNhapKhoService phieuNhapKhoService) : base(loiService)
        {
            this._chungTuBanHanggService = chungTuBanHanggService;
            this._khachHangService = khachHangService;
            this._nhanVienService = nhanVienService;
            this._coSoService = coSoService;
            this._hangHoaService = hangHoaService;
            this._phieuNhapKhoService = phieuNhapKhoService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChungTuBanHangViewModel> chungTuBanHanggVM)
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
        //            foreach (var item in chungTuBanHanggVM)
        //            {
        //                var newThongBao = new ChungTuBanHang();
        //                newThongBao.UpdateChungTuBanHang(item);

        //                _chungTuBanHanggService.Add(newThongBao);
        //                _chungTuBanHanggService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}


        [Route("update")]
        [HttpPut]
        public HttpResponseMessage update(HttpRequestMessage request, ChungTuBanHangViewModel chungTuBanHanggViewModel)

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

                    var vienchucDb = _chungTuBanHanggService.GetByID((chungTuBanHanggViewModel.MaChungTuBanHang));

                    vienchucDb.UpdateChungTuBanHang(chungTuBanHanggViewModel);
                    _chungTuBanHanggService.Update(vienchucDb);
                    _chungTuBanHanggService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }





        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ChungTuBanHangViewModel khachHang)
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
                    var newThongBao = new ChungTuBanHang();
                    newThongBao.UpdateChungTuBanHang(khachHang);

                    _chungTuBanHanggService.Add(newThongBao);
                    _chungTuBanHanggService.Save();
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


                var listCategory = _chungTuBanHanggService.GetAll();
              //  var responseData = Mapper.Map<IEnumerable<ChungTuBanHang>,IEnumerable<ChungTuBanHangViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

        [Route("getchungtubanhang")]
        public HttpResponseMessage getchungtubanhang(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chungTuBanHanggService.getchungtubanhang(ngaydau, ngaycuoi);
                //  var responseData = Mapper.Map<IEnumerable<ChungTuBanHang>,IEnumerable<ChungTuBanHangViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getbyid")]
         [HttpGet]
        public HttpResponseMessage getbyid(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chungTuBanHanggService.GetByID(id);
                var ctbh = Mapper.Map<ChungTuBanHang,ChungTuBanHangViewModel>(listCategory);
                if (ctbh!=null)
                {
                    ctbh.KhachHang = _khachHangService.GetByID(ctbh.MaKhachHang);
                    var a = _nhanVienService.getbymsnv(ctbh.MaSoNhanVien);
                    ctbh.NhanVienVangMat = Mapper.Map<IEnumerable<NhanVienVangMat>>(a);

                }


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, ctbh);


                return response;
            });
        }


        [Route("gettheongay")]
        [HttpGet]
        public HttpResponseMessage gettheongay(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi,bool dathaydoi, int machucvu,string manv,string macoso)
        {
            return CreateHttpResponse(request, () =>
            {

                var allcoso = _coSoService.GetAll();
                IEnumerable<thongkechungtucoso> coso=new List<thongkechungtucoso>();
                  foreach (var item in allcoso)
                {
                    thongkechungtucoso tam = new thongkechungtucoso();
                    IEnumerable<getchungtubanhang> allcosobydate = _chungTuBanHanggService.getctbh(ngaydau, ngaycuoi, item.MaCoSo, dathaydoi);
                    var sapxep = allcosobydate.OrderBy(x => x.NgayChungTu);
                    IEnumerable<getchungtubanhang> filteredValues = new List<getchungtubanhang>();

                    if (machucvu == 59)
                    {
                         filteredValues = sapxep.Where(x=>x.MaSoNhanVien== manv);

                    }
                    else if (78<=machucvu&&machucvu<=79)
                    {
                        var a = sapxep.Where(x => x.MaCoSo == macoso);
                        if (manv==null)
                        {
                            filteredValues = a;
                        }
                        else
                        {
                            filteredValues = a.Where(x => x.MaSoNhanVien == manv);
                        }
                    }
                     else if (98<=machucvu&&machucvu<=99)
                    {
                        
                        if (macoso == null)
                        {
                            filteredValues = sapxep;
                        }
                        else
                        {
                            filteredValues = sapxep.Where(x => x.MaCoSo == macoso);
                        }
                    }
                    
                    //var a = Mapper.Map<IEnumerable<getchungtubanhang>>(allcosobydate);
                    if (filteredValues.Count() > 0)
                    {
                        tam.TenCoSo = item.TenCoSo;
                        tam.ChungTuBanHang = filteredValues;
                        ((List<thongkechungtucoso>)coso).Add(tam);

                    }

                }

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, coso);
                return response;
            });
        }

        [Route("getlichsu")]
        [HttpGet]
        public HttpResponseMessage getlichsu(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {

                var chungtubanhang = _chungTuBanHanggService.getlichsu().OrderByDescending(x=>x.Ngay);
                var hanghoa = _hangHoaService.getlichsu().OrderByDescending(x => x.Ngay);
                var nhapkho = _phieuNhapKhoService.getlichsu().OrderByDescending(x => x.Ngay);
                var test = Mapper.Map<IEnumerable<lichsutongquan>>(nhapkho);
                var all = (chungtubanhang.Concat(hanghoa).Concat(nhapkho)).OrderByDescending(x=>x.Ngay).Take(20);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, all);
                return response;
            });
        }

        [Route("getthongketimeline")]
        [HttpGet]
        public HttpResponseMessage getthongketimeline(HttpRequestMessage request,string mactbh)
        {
            return CreateHttpResponse(request, () =>
            {
                var nhapkho = _chungTuBanHanggService.getthongkechungtubanhangtimeline(mactbh);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, nhapkho);
                return response;
            });
        }












       

       
    }
}
