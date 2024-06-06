package crc64e1247576af304310;


public class FinancialSeriesDataAdapter
	extends crc64e1247576af304310.XYSeriesDataAdapter
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.FinancialSeriesData,
		com.devexpress.dxcharts.XYSeriesData
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getDataCount:()I:GetGetDataCountHandler:DevExpress.Android.Charts.IFinancialSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getArgument:(I)Ljava/util/Date;:GetGetArgument_IHandler:DevExpress.Android.Charts.IFinancialSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getCloseValue:(I)D:GetGetCloseValue_IHandler:DevExpress.Android.Charts.IFinancialSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getHighValue:(I)D:GetGetHighValue_IHandler:DevExpress.Android.Charts.IFinancialSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getLowValue:(I)D:GetGetLowValue_IHandler:DevExpress.Android.Charts.IFinancialSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getOpenValue:(I)D:GetGetOpenValue_IHandler:DevExpress.Android.Charts.IFinancialSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.FinancialSeriesDataAdapter, DevExpress.Maui.Charts", FinancialSeriesDataAdapter.class, __md_methods);
	}


	public FinancialSeriesDataAdapter ()
	{
		super ();
		if (getClass () == FinancialSeriesDataAdapter.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.FinancialSeriesDataAdapter, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public int getDataCount ()
	{
		return n_getDataCount ();
	}

	private native int n_getDataCount ();


	public java.util.Date getArgument (int p0)
	{
		return n_getArgument (p0);
	}

	private native java.util.Date n_getArgument (int p0);


	public double getCloseValue (int p0)
	{
		return n_getCloseValue (p0);
	}

	private native double n_getCloseValue (int p0);


	public double getHighValue (int p0)
	{
		return n_getHighValue (p0);
	}

	private native double n_getHighValue (int p0);


	public double getLowValue (int p0)
	{
		return n_getLowValue (p0);
	}

	private native double n_getLowValue (int p0);


	public double getOpenValue (int p0)
	{
		return n_getOpenValue (p0);
	}

	private native double n_getOpenValue (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
