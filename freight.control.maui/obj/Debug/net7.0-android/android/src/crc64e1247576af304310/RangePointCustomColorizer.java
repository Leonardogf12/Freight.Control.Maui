package crc64e1247576af304310;


public class RangePointCustomColorizer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.RangeCustomPointColorizer,
		com.devexpress.dxcharts.RangePointColorizer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getLegendItemProvider:()Lcom/devexpress/dxcharts/LegendItemProvider;:GetGetLegendItemProviderHandler:DevExpress.Android.Charts.IRangeCustomPointColorizerInvoker, DevExpress.Android.Charts\n" +
			"n_getColor:(Lcom/devexpress/dxcharts/ColoredRangePointInfo;)I:GetGetColor_Lcom_devexpress_dxcharts_ColoredRangePointInfo_Handler:DevExpress.Android.Charts.IRangeCustomPointColorizerInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.RangePointCustomColorizer, DevExpress.Maui.Charts", RangePointCustomColorizer.class, __md_methods);
	}


	public RangePointCustomColorizer ()
	{
		super ();
		if (getClass () == RangePointCustomColorizer.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.RangePointCustomColorizer, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public com.devexpress.dxcharts.LegendItemProvider getLegendItemProvider ()
	{
		return n_getLegendItemProvider ();
	}

	private native com.devexpress.dxcharts.LegendItemProvider n_getLegendItemProvider ();


	public int getColor (com.devexpress.dxcharts.ColoredRangePointInfo p0)
	{
		return n_getColor (p0);
	}

	private native int n_getColor (com.devexpress.dxcharts.ColoredRangePointInfo p0);

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
