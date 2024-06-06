package crc64e1247576af304310;


public class PieSeriesDataAdapter
	extends crc64e1247576af304310.ChangableSeriesDataAdapter
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.PieSeriesData
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getDataCount:()I:GetGetDataCountHandler:DevExpress.Android.Charts.IPieSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getLabel:(I)Ljava/lang/String;:GetGetLabel_IHandler:DevExpress.Android.Charts.IPieSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getValue:(I)D:GetGetValue_IHandler:DevExpress.Android.Charts.IPieSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.PieSeriesDataAdapter, DevExpress.Maui.Charts", PieSeriesDataAdapter.class, __md_methods);
	}


	public PieSeriesDataAdapter ()
	{
		super ();
		if (getClass () == PieSeriesDataAdapter.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.PieSeriesDataAdapter, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public int getDataCount ()
	{
		return n_getDataCount ();
	}

	private native int n_getDataCount ();


	public java.lang.String getLabel (int p0)
	{
		return n_getLabel (p0);
	}

	private native java.lang.String n_getLabel (int p0);


	public double getValue (int p0)
	{
		return n_getValue (p0);
	}

	private native double n_getValue (int p0);

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
