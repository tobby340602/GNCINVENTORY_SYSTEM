using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGoogleVisionBarcodeScanningSample.Models
{
    public class Order_Master
    {
        public string ORDNUM_10 { get; set; }
        public string LINNUM_10 { get; set; }
        public string DELNUM_10 { get; set; }
        public string PRTNUM_10 { get; set; }
        public DateTime CURDUE_10 { get; set; }
        public string RECFLG_10 { get; set; }
        public string TAXABLE_10 { get; set; }
        public string TYPE_10 { get; set; }
        public string ORDER_10 { get; set; }
        public string VENID_10 { get; set; }
        public DateTime ORGDUE_10 { get; set; }
        public string PURUOM_10 { get; set; }
        public double CURQTY_10 { get; set; }
        public double ORGQTY_10 { get; set; }
        public double DUEQTY_10 { get; set; }
        public DateTime CURPRM_10 { get; set; }
        public string FILL03_10 { get; set; }
        public DateTime ORGPRM_10 { get; set; }
        public string FILL04_10 { get; set; }
        public string FRMPLN_10 { get; set; }
        public string STATUS_10 { get; set; }
        public string STK_10 { get; set; }
        public string CUSORD_10 { get; set; }
        public string PLANID_10 { get; set; }
        public string BUYER_10 { get; set; }
        public double PSCRAP_10 { get; set; }
        public double ASCRAP_10 { get; set; }
        public string SCRPCD_10 { get; set; }
        public string SCHCDE_10 { get; set; }
        public string REVLEV_10 { get; set; }
        public double COST_10 { get; set; }
        public double CSTCNV_10 { get; set; }
        public string APRDBY_10 { get; set; }
        public string ORDREF_10 { get; set; }
        public DateTime TRNDTE_10 { get; set; }
        public string FILL05_10 { get; set; }
        public string SCHFLG_10 { get; set; }
        public string CRTRAT_10 { get; set; }
        public string NEGATV_10 { get; set; }
        public string REQPEG_10 { get; set; }
        public string MPNNUM_10 { get; set; }
        public double LABOR_10 { get; set; }
        public string AMMEND_10 { get; set; }
        public string LOTNUM_10 { get; set; }
        public string BEGSER_10 { get; set; }
        public string REWORK_10 { get; set; }
        public string CRTSNS_10 { get; set; }
        public double TTLSNS_10 { get; set; }
        public double FORCUR_10 { get; set; }
        public Single EXCESS_10 { get; set; }
        public double UOMCST_10 { get; set; }
        public double UOMCNV_10 { get; set; }
        public string INSREQ_10 { get; set; }
        public DateTime CREDTE_10 { get; set; }
        public string RTEREV_10 { get; set; }
        public DateTime RTEDTE_10 { get; set; }
        public string COMCDE_10 { get; set; }
        public string ORDPTP_10 { get; set; }
        public string JOBEXP_10 { get; set; }
        public double JOBCST_10 { get; set; }
        public string TAXCDE_10 { get; set; }
        public double TAX1_10 { get; set; }
        public string GLREF_10 { get; set; }
        public string CURR_10 { get; set; }
        public string UDFKEY_10 { get; set; }
        public string UDFREF_10 { get; set; }
        public Single DISC_10 { get; set; }
        public double RECCOST_10 { get; set; }
        public string MPNMFG_10 { get; set; }
        public string DEXPFLG_10 { get; set; }
        public string PLSTPRNT_10 { get; set; }
        public string ROUTPRNT_10 { get; set; }
        public string REQUES_10 { get; set; }
        public DateTime CLSDTE_10 { get; set; }
        public int XDFINT_10 { get; set; }
        public double XDFFLT_10 { get; set; }
        public string XDFBOL_10 { get; set; }
        public DateTime XDFDTE_10 { get; set; }
        public string XDFTXT_10 { get; set; }
        public string FILLER_10 { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModificationDate { get; set; }
        public string TSKCDE_10 { get; set; }
        public string TSKTYP_10 { get; set; }
        public string REPORTER_10 { get; set; }
        public string PRIORITY_10 { get; set; }
        public string PHONE_10 { get; set; }
        public string LOCATION_10 { get; set; }
        public string ALTBOM_10 { get; set; }
        public string ALTRTG_10 { get; set; }
        public string CLASS_10 { get; set; }
        public string JOB_10 { get; set; }
        public double SUBSHP_10 { get; set; }

        public Order_Master(string ORDNUM_10_, string LINNUM_10_, string DELNUM_10_, string PRTNUM_10_, DateTime CURDUE_10_, string RECFLG_10_, string TAXABLE_10_, string TYPE_10_, string ORDER_10_, string VENID_10_, DateTime ORGDUE_10_, string PURUOM_10_, double CURQTY_10_, double ORGQTY_10_, double DUEQTY_10_, DateTime CURPRM_10_, string FILL03_10_, DateTime ORGPRM_10_, string FILL04_10_, string FRMPLN_10_, string STATUS_10_, string STK_10_, string CUSORD_10_, string PLANID_10_, string BUYER_10_, double PSCRAP_10_, double ASCRAP_10_, string SCRPCD_10_, string SCHCDE_10_, string REVLEV_10_, double COST_10_, double CSTCNV_10_, string APRDBY_10_, string ORDREF_10_, DateTime TRNDTE_10_, string FILL05_10_, string SCHFLG_10_, string CRTRAT_10_, string NEGATV_10_, string REQPEG_10_, string MPNNUM_10_, double LABOR_10_, string AMMEND_10_, string LOTNUM_10_, string BEGSER_10_, string REWORK_10_, string CRTSNS_10_, double TTLSNS_10_, double FORCUR_10_, Single EXCESS_10_, double UOMCST_10_, double UOMCNV_10_, string INSREQ_10_, DateTime CREDTE_10_, string RTEREV_10_, DateTime RTEDTE_10_, string COMCDE_10_, string ORDPTP_10_, string JOBEXP_10_, double JOBCST_10_, string TAXCDE_10_, double TAX1_10_, string GLREF_10_, string CURR_10_, string UDFKEY_10_, string UDFREF_10_, Single DISC_10_, double RECCOST_10_, string MPNMFG_10_, string DEXPFLG_10_, string PLSTPRNT_10_, string ROUTPRNT_10_, string REQUES_10_, DateTime CLSDTE_10_, int XDFINT_10_, double XDFFLT_10_, string XDFBOL_10_, DateTime XDFDTE_10_, string XDFTXT_10_, string FILLER_10_, string CreatedBy_, DateTime CreationDate_, string ModifiedBy_, DateTime ModificationDate_, string TSKCDE_10_, string TSKTYP_10_, string REPORTER_10_, string PRIORITY_10_, string PHONE_10_, string LOCATION_10_, string ALTBOM_10_, string ALTRTG_10_, string CLASS_10_, string JOB_10_, double SUBSHP_10_)
        {
            this.ORDNUM_10 = ORDNUM_10_;
            this.LINNUM_10 = LINNUM_10_;
            this.DELNUM_10 = DELNUM_10_;
            this.PRTNUM_10 = PRTNUM_10_;
            this.CURDUE_10 = CURDUE_10_;
            this.RECFLG_10 = RECFLG_10_;
            this.TAXABLE_10 = TAXABLE_10_;
            this.TYPE_10 = TYPE_10_;
            this.ORDER_10 = ORDER_10_;
            this.VENID_10 = VENID_10_;
            this.ORGDUE_10 = ORGDUE_10_;
            this.PURUOM_10 = PURUOM_10_;
            this.CURQTY_10 = CURQTY_10_;
            this.ORGQTY_10 = ORGQTY_10_;
            this.DUEQTY_10 = DUEQTY_10_;
            this.CURPRM_10 = CURPRM_10_;
            this.FILL03_10 = FILL03_10_;
            this.ORGPRM_10 = ORGPRM_10_;
            this.FILL04_10 = FILL04_10_;
            this.FRMPLN_10 = FRMPLN_10_;
            this.STATUS_10 = STATUS_10_;
            this.STK_10 = STK_10_;
            this.CUSORD_10 = CUSORD_10_;
            this.PLANID_10 = PLANID_10_;
            this.BUYER_10 = BUYER_10_;
            this.PSCRAP_10 = PSCRAP_10_;
            this.ASCRAP_10 = ASCRAP_10_;
            this.SCRPCD_10 = SCRPCD_10_;
            this.SCHCDE_10 = SCHCDE_10_;
            this.REVLEV_10 = REVLEV_10_;
            this.COST_10 = COST_10_;
            this.CSTCNV_10 = CSTCNV_10_;
            this.APRDBY_10 = APRDBY_10_;
            this.ORDREF_10 = ORDREF_10_;
            this.TRNDTE_10 = TRNDTE_10_;
            this.FILL05_10 = FILL05_10_;
            this.SCHFLG_10 = SCHFLG_10_;
            this.CRTRAT_10 = CRTRAT_10_;
            this.NEGATV_10 = NEGATV_10_;
            this.REQPEG_10 = REQPEG_10_;
            this.MPNNUM_10 = MPNNUM_10_;
            this.LABOR_10 = LABOR_10_;
            this.AMMEND_10 = AMMEND_10_;
            this.LOTNUM_10 = LOTNUM_10_;
            this.BEGSER_10 = BEGSER_10_;
            this.REWORK_10 = REWORK_10_;
            this.CRTSNS_10 = CRTSNS_10_;
            this.TTLSNS_10 = TTLSNS_10_;
            this.FORCUR_10 = FORCUR_10_;
            this.EXCESS_10 = EXCESS_10_;
            this.UOMCST_10 = UOMCST_10_;
            this.UOMCNV_10 = UOMCNV_10_;
            this.INSREQ_10 = INSREQ_10_;
            this.CREDTE_10 = CREDTE_10_;
            this.RTEREV_10 = RTEREV_10_;
            this.RTEDTE_10 = RTEDTE_10_;
            this.COMCDE_10 = COMCDE_10_;
            this.ORDPTP_10 = ORDPTP_10_;
            this.JOBEXP_10 = JOBEXP_10_;
            this.JOBCST_10 = JOBCST_10_;
            this.TAXCDE_10 = TAXCDE_10_;
            this.TAX1_10 = TAX1_10_;
            this.GLREF_10 = GLREF_10_;
            this.CURR_10 = CURR_10_;
            this.UDFKEY_10 = UDFKEY_10_;
            this.UDFREF_10 = UDFREF_10_;
            this.DISC_10 = DISC_10_;
            this.RECCOST_10 = RECCOST_10_;
            this.MPNMFG_10 = MPNMFG_10_;
            this.DEXPFLG_10 = DEXPFLG_10_;
            this.PLSTPRNT_10 = PLSTPRNT_10_;
            this.ROUTPRNT_10 = ROUTPRNT_10_;
            this.REQUES_10 = REQUES_10_;
            this.CLSDTE_10 = CLSDTE_10_;
            this.XDFINT_10 = XDFINT_10_;
            this.XDFFLT_10 = XDFFLT_10_;
            this.XDFBOL_10 = XDFBOL_10_;
            this.XDFDTE_10 = XDFDTE_10_;
            this.XDFTXT_10 = XDFTXT_10_;
            this.FILLER_10 = FILLER_10_;
            this.CreatedBy = CreatedBy_;
            this.CreationDate = CreationDate_;
            this.ModifiedBy = ModifiedBy_;
            this.ModificationDate = ModificationDate_;
            this.TSKCDE_10 = TSKCDE_10_;
            this.TSKTYP_10 = TSKTYP_10_;
            this.REPORTER_10 = REPORTER_10_;
            this.PRIORITY_10 = PRIORITY_10_;
            this.PHONE_10 = PHONE_10_;
            this.LOCATION_10 = LOCATION_10_;
            this.ALTBOM_10 = ALTBOM_10_;
            this.ALTRTG_10 = ALTRTG_10_;
            this.CLASS_10 = CLASS_10_;
            this.JOB_10 = JOB_10_;
            this.SUBSHP_10 = SUBSHP_10_;
        }
    }
}
