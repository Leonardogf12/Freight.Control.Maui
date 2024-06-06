package crc64e1247576af304310;


public class WeightedDateTimeSeriesDataAdapter
	extends crc64e1247576af304310.XYSeriesDataAdapter
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.WeightedDateTimeSeriesData,
		com.devexpress.dxcharts.DateTimeSeriesData,
		com.devexpress.dxcharts.XYSeriesData
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getWeight:(I)D:GetGetWeight_IHandler:DevExpress.Android.Charts.IWeightedDateTimeSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getDataCount:()I:GetGetDataCountHandler:DevExpress.Android.Charts.IDateTimeSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getArgument:(I)Ljava/util/Date;:GetGetArgument_IHandler:DevExpress.Android.Charts.IDateTimeSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getValue:(I)D:GetGetValue_IHandler:DevExpress.Android.Charts.IDateTimeSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.WeightedDateTimeSeriesDataAdapter, DevExpress.Maui.Charts", WeightedDateTimeSeriesDataAdapter.class, __md_methods);
	}


	public WeightedDateTimeSeriesDataAdapter ()
	{
		super ();
		if (getClass () == WeightedDateTimeSeriesDataAdapter.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.WeightedDateTimeSeriesDataAdapter, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public double getWeight (int p0)
	{
		return n_getWeight (p0);
	}

	private native double n_getWeight (int p0);


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
