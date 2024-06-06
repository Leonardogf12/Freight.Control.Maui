package crc64e1247576af304310;


public class CustomColorizerNumericValueProvider
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.dxcharts.CustomColorizerNumericValueProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getValueForColorizer:(I)D:GetGetValueForColorizer_IHandler:DevExpress.Android.Charts.ICustomColorizerNumericValueProviderInvoker, DevExpress.Android.Charts\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Charts.Android.Internal.CustomColorizerNumericValueProvider, DevExpress.Maui.Charts", CustomColorizerNumericValueProvider.class, __md_methods);
	}


	public CustomColorizerNumericValueProvider ()
	{
		super ();
		if (getClass () == CustomColorizerNumericValueProvider.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Charts.Android.Internal.CustomColorizerNumericValueProvider, DevExpress.Maui.Charts", "", this, new java.lang.Object[] {  });
		}
	}


	public double getValueForColorizer (int p0)
	{
		return n_getValueForColorizer (p0);
	}

	private native double n_getValueForColorizer (int p0);

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
