package crc64e1247576af304310;


public class PointTextProvider
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.PointTextProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getText:(Lcom/devexpress/dxcharts/SeriesPointInfo;)Ljava/lang/String;:GetGetText_Lcom_devexpress_dxcharts_SeriesPointInfo_Handler:DevExpress.Android.Charts.IPointTextProviderInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.PointTextProvider, DevExpress.Maui.Charts", PointTextProvider.class, __md_methods);
	}


	public PointTextProvider ()
	{
		super ();
		if (getClass () == PointTextProvider.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.PointTextProvider, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public java.lang.String getText (com.devexpress.dxcharts.SeriesPointInfo p0)
	{
		return n_getText (p0);
	}

	private native java.lang.String n_getText (com.devexpress.dxcharts.SeriesPointInfo p0);

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
