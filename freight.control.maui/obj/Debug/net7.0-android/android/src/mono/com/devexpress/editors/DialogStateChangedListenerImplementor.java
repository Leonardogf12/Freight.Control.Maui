package mono.com.devexpress.editors;


public class DialogStateChangedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.editors.DialogStateChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDialogStateChanged:(Lcom/devexpress/editors/EditBase;Z)V:GetOnDialogStateChanged_Lcom_devexpress_editors_EditBase_ZHandler:DevExpress.Android.Editors.IDialogStateChangedListenerInvoker, DevExpress.Android.Editors\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Android.Editors.IDialogStateChangedListenerImplementor, DevExpress.Android.Editors", DialogStateChangedListenerImplementor.class, __md_methods);
	}


	public DialogStateChangedListenerImplementor ()
	{
		super ();
		if (getClass () == DialogStateChangedListenerImplementor.class) {
			mono.android.TypeManager.Activate ("DevExpress.Android.Editors.IDialogStateChangedListenerImplementor, DevExpress.Android.Editors", "", this, new java.lang.Object[] {  });
		}
	}


	public void onDialogStateChanged (com.devexpress.editors.EditBase p0, boolean p1)
	{
		n_onDialogStateChanged (p0, p1);
	}

	private native void n_onDialogStateChanged (com.devexpress.editors.EditBase p0, boolean p1);

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
