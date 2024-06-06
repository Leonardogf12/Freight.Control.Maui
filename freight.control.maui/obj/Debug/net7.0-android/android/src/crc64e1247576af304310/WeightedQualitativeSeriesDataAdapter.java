package crc64e1247576af304310;


public class WeightedQualitativeSeriesDataAdapter
	extends crc64e1247576af304310.QualitativeSeriesDataAdapter
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.WeightedQualitativeSeriesData,
		com.devexpress.dxcharts.QualitativeSeriesData,
		com.devexpress.dxcharts.XYSeriesData
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getWeight:(I)D:GetGetWeight_IHandler:DevExpress.Android.Charts.IWeightedQualitativeSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getDataCount:()I:GetGetDataCountHandler:DevExpress.Android.Charts.IQualitativeSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getArgument:(I)Ljava/lang/String;:GetGetArgument_IHandler:DevExpress.Android.Charts.IQualitativeSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"n_getValue:(I)D:GetGetValue_IHandler:DevExpress.Android.Charts.IQualitativeSeriesDataInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.WeightedQualitativeSeriesDataAdapter, DevExpress.Maui.Charts", WeightedQualitativeSeriesDataAdapter.class, __md_methods);
	}


	public WeightedQualitativeSeriesDataAdapter ()
	{
		super ();
		if (getClass () == WeightedQualitativeSeriesDataAdapter.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.WeightedQualitativeSeriesDataAdapter, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
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


	public java.lang.String getArgument (int p0)
	{
		return n_getArgument (p0);
	}

	private native java.lang.String n_getArgument (int p0);


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
