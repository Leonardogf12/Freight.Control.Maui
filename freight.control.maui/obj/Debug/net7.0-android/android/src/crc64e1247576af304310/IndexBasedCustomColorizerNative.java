package crc64e1247576af304310;


public class IndexBasedCustomColorizerNative
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.IndexBasedCustomPointColorizer,
		com.devexpress.dxcharts.PointColorizer,
		com.devexpress.dxcharts.RangePointColorizer,
		com.devexpress.dxcharts.StackedPointColorizer,
		com.devexpress.dxcharts.WeightedPointColorizer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getLegendItemProvider:()Lcom/devexpress/dxcharts/LegendItemProvider;:GetGetLegendItemProviderHandler:DevExpress.Android.Charts.IIndexBasedCustomPointColorizerInvoker, DevExpress.Android.Charts\n" +
			"n_getColor:(I)I:GetGetColor_IHandler:DevExpress.Android.Charts.IIndexBasedCustomPointColorizerInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.IndexBasedCustomColorizerNative, DevExpress.Maui.Charts", IndexBasedCustomColorizerNative.class, __md_methods);
	}


	public IndexBasedCustomColorizerNative ()
	{
		super ();
		if (getClass () == IndexBasedCustomColorizerNative.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.IndexBasedCustomColorizerNative, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public com.devexpress.dxcharts.LegendItemProvider getLegendItemProvider ()
	{
		return n_getLegendItemProvider ();
	}

	private native com.devexpress.dxcharts.LegendItemProvider n_getLegendItemProvider ();


	public int getColor (int p0)
	{
		return n_getColor (p0);
	}

	private native int n_getColor (int p0);

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
