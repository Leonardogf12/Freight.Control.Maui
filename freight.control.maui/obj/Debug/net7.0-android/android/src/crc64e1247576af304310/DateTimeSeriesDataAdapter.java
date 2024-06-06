package crc64e1247576af304310;


public class DateTimeSeriesDataAdapter
	extends crc64e1247576af304310.XYSeriesDataAdapter
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.BatchDateTimeAsNumericSeriesData,
		com.devexpress.dxcharts.XYSeriesData
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getDataCount:()I:GetGetDataCountHandler:DevExpress.Android.Charts.IBatchDateTimeAsNumericSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_fillArguments:([DII)I:GetFillArguments_arrayDIIHandler:DevExpress.Android.Charts.IBatchDateTimeAsNumericSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_fillValues:([DII)I:GetFillValues_arrayDIIHandler:DevExpress.Android.Charts.IBatchDateTimeAsNumericSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getArgument:(I)D:GetGetArgument_IHandler:DevExpress.Android.Charts.IBatchDateTimeAsNumericSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getValue:(I)D:GetGetValue_IHandler:DevExpress.Android.Charts.IBatchDateTimeAsNumericSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.DateTimeSeriesDataAdapter, DevExpress.Maui.Charts", DateTimeSeriesDataAdapter.class, __md_methods);
	}


	public DateTimeSeriesDataAdapter ()
	{
		super ();
		if (getClass () == DateTimeSeriesDataAdapter.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.DateTimeSeriesDataAdapter, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public int getDataCount ()
	{
		return n_getDataCount ();
	}

	private native int n_getDataCount ();


	public int fillArguments (double[] p0, int p1, int p2)
	{
		return n_fillArguments (p0, p1, p2);
	}

	private native int n_fillArguments (double[] p0, int p1, int p2);


	public int fillValues (double[] p0, int p1, int p2)
	{
		return n_fillValues (p0, p1, p2);
	}

	private native int n_fillValues (double[] p0, int p1, int p2);


	public double getArgument (int p0)
	{
		return n_getArgument (p0);
	}

	private native double n_getArgument (int p0);


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
