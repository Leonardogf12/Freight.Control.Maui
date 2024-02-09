package crc644741187cca50a741;


public class DXRippleEffectViewGroup
	extends crc6452ffdc5b34af3a0f.ContentViewGroup
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"n_onDrawForeground:(Landroid/graphics/Canvas;)V:GetOnDrawForeground_Landroid_graphics_Canvas_Handler\n" +
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"n_invalidateDrawable:(Landroid/graphics/drawable/Drawable;)V:GetInvalidateDrawable_Landroid_graphics_drawable_Drawable_Handler\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Editors.Android.Internal.DXRippleEffectViewGroup, DevExpress.Maui.Editors", DXRippleEffectViewGroup.class, __md_methods);
	}


	public DXRippleEffectViewGroup (android.content.Context p0)
	{
		super (p0);
		if (getClass () == DXRippleEffectViewGroup.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Editors.Android.Internal.DXRippleEffectViewGroup, DevExpress.Maui.Editors", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public DXRippleEffectViewGroup (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == DXRippleEffectViewGroup.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Editors.Android.Internal.DXRippleEffectViewGroup, DevExpress.Maui.Editors", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public DXRippleEffectViewGroup (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == DXRippleEffectViewGroup.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Editors.Android.Internal.DXRippleEffectViewGroup, DevExpress.Maui.Editors", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public DXRippleEffectViewGroup (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == DXRippleEffectViewGroup.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Editors.Android.Internal.DXRippleEffectViewGroup, DevExpress.Maui.Editors", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3 });
		}
	}


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);


	public void onDrawForeground (android.graphics.Canvas p0)
	{
		n_onDrawForeground (p0);
	}

	private native void n_onDrawForeground (android.graphics.Canvas p0);


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);


	public void invalidateDrawable (android.graphics.drawable.Drawable p0)
	{
		n_invalidateDrawable (p0);
	}

	private native void n_invalidateDrawable (android.graphics.drawable.Drawable p0);

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
