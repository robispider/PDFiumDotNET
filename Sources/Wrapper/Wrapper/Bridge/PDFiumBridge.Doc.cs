﻿namespace PDFiumDotNET.Wrapper.Bridge
{
    using System;
    using System.Runtime.InteropServices;

    // Disable "Member 'xxxx' does not access instance data and can be marked as static."
#pragma warning disable CA1822

    /// <summary>
    /// The class contains all pdfium methods currently supported in this project.
    /// </summary>
    public sealed partial class PDFiumBridge
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_BOOKMARK FPDFBookmark_GetFirstChild_Delegate(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);

        private static FPDFBookmark_GetFirstChild_Delegate FPDFBookmark_GetFirstChildStatic { get; set; }

        /// <summary>
        /// Get the first child of |bookmark|, or the first top-level bookmark item.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="bookmark">Handle to the current bookmark. Pass NULL for the first top level item.</param>
        /// <returns>Returns a handle to the first child of |bookmark| or the first top-level bookmark item. NULL if no child or top-level bookmark found.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_BOOKMARK FPDF_CALLCONV FPDFBookmark_GetFirstChild(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);.
        /// </remarks>
        public FPDF_BOOKMARK FPDFBookmark_GetFirstChild(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark)
        {
            lock (_syncObject)
            {
                return FPDFBookmark_GetFirstChildStatic(document, bookmark);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_BOOKMARK FPDFBookmark_GetNextSibling_Delegate(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);

        private static FPDFBookmark_GetNextSibling_Delegate FPDFBookmark_GetNextSiblingStatic { get; set; }

        /// <summary>
        /// Get the next sibling of |bookmark|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="bookmark">Handle to the current bookmark.</param>
        /// <returns>Returns a handle to the next sibling of |bookmark|, or NULL if this is the last bookmark at this level.</returns>
        /// <remarks>
        /// Note that the caller is responsible for handling circular bookmark references, as may arise from malformed documents.
        /// FPDF_EXPORT FPDF_BOOKMARK FPDF_CALLCONV FPDFBookmark_GetNextSibling(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);.
        /// </remarks>
        public FPDF_BOOKMARK FPDFBookmark_GetNextSibling(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark)
        {
            lock (_syncObject)
            {
                return FPDFBookmark_GetNextSiblingStatic(document, bookmark);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFBookmark_GetTitle_Delegate(FPDF_BOOKMARK bookmark, IntPtr buffer, ulong buflen);

        private static FPDFBookmark_GetTitle_Delegate FPDFBookmark_GetTitleStatic { get; set; }

        /// <summary>
        /// Get the title of |bookmark|.
        /// </summary>
        /// <param name="bookmark">Handle to the bookmark.</param>
        /// <param name="buffer">Buffer for the title. May be NULL.</param>
        /// <param name="buflen">The length of the buffer in bytes. May be 0.</param>
        /// <returns>Returns the number of bytes in the title, including the terminating NUL character.
        /// The number of bytes is returned regardless of the |buffer| and |buflen| parameters.</returns>
        /// <remarks>
        /// Regardless of the platform, the |buffer| is always in UTF-16LE encoding. The string is terminated by a UTF16 NUL character.
        /// If |buflen| is less than the required length, or |buffer| is NULL, |buffer| will not be modified.
        /// FPDF_EXPORT unsigned long FPDF_CALLCONV FPDFBookmark_GetTitle(FPDF_BOOKMARK bookmark, void* buffer, unsigned long buflen);.
        /// </remarks>
        public int FPDFBookmark_GetTitle(FPDF_BOOKMARK bookmark, IntPtr buffer, ulong buflen)
        {
            lock (_syncObject)
            {
                return FPDFBookmark_GetTitleStatic(bookmark, buffer, buflen);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFBookmark_GetCount_Delegate(FPDF_BOOKMARK bookmark);

        private static FPDFBookmark_GetCount_Delegate FPDFBookmark_GetCountStatic { get; set; }

        /// <summary>
        /// Experimental API.
        /// Get the number of chlidren of |bookmark|.
        /// </summary>
        /// <param name="bookmark">Handle to the bookmark.</param>
        /// <returns>
        /// Returns a signed integer that represents the number of sub-items the given bookmark has.
        /// If the value is positive, child items shall be shown by default (open state).
        /// If the value is negative, child items shall be hidden by default (closed state).
        /// Please refer to PDF 32000-1:2008, Table 153.
        /// Returns 0 if the bookmark has no children or is invalid.</returns>
        public int FPDFBookmark_GetCount(FPDF_BOOKMARK bookmark)
        {
            lock (_syncObject)
            {
                return FPDFBookmark_GetCountStatic(bookmark);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_BOOKMARK FPDFBookmark_Find_Delegate(FPDF_DOCUMENT document, IntPtr title);

        private static FPDFBookmark_Find_Delegate FPDFBookmark_FindStatic { get; set; }

        /// <summary>
        /// Find the bookmark with |title| in |document|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="title">The UTF-16LE encoded Unicode title for which to search.</param>
        /// <returns>Returns the handle to the bookmark, or NULL if |title| can't be found.</returns>
        /// <remarks>
        /// FPDFBookmark_Find() will always return the first bookmark found even if multiple bookmarks have the same |title|.
        /// FPDF_EXPORT FPDF_BOOKMARK FPDF_CALLCONV FPDFBookmark_Find(FPDF_DOCUMENT document, FPDF_WIDESTRING title);.
        /// </remarks>
        public FPDF_BOOKMARK FPDFBookmark_Find(FPDF_DOCUMENT document, IntPtr title)
        {
            lock (_syncObject)
            {
                return FPDFBookmark_FindStatic(document, title);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_DEST FPDFBookmark_GetDest_Delegate(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);

        private static FPDFBookmark_GetDest_Delegate FPDFBookmark_GetDestStatic { get; set; }

        /// <summary>
        /// Get the destination associated with |bookmark|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="bookmark">Handle to the bookmark.</param>
        /// <returns>Returns the handle to the destination data,  NULL if no destination is associated with |bookmark|.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_DEST FPDF_CALLCONV FPDFBookmark_GetDest(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark);.
        /// </remarks>
        public FPDF_DEST FPDFBookmark_GetDest(FPDF_DOCUMENT document, FPDF_BOOKMARK bookmark)
        {
            lock (_syncObject)
            {
                return FPDFBookmark_GetDestStatic(document, bookmark);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_ACTION FPDFBookmark_GetAction_Delegate(FPDF_BOOKMARK bookmark);

        private static FPDFBookmark_GetAction_Delegate FPDFBookmark_GetActionStatic { get; set; }

        /// <summary>
        /// Get the action associated with |bookmark|.
        /// </summary>
        /// <param name="bookmark">Handle to the bookmark.</param>
        /// <returns>Returns the handle to the action data, or NULL if no action is associated with |bookmark|.
        /// When NULL is returned, FPDFBookmark_GetDest() should be called to get the |bookmark| destination data.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_ACTION FPDF_CALLCONV FPDFBookmark_GetAction(FPDF_BOOKMARK bookmark);.
        /// </remarks>
        public FPDF_ACTION FPDFBookmark_GetAction(FPDF_BOOKMARK bookmark)
        {
            lock (_syncObject)
            {
                return FPDFBookmark_GetActionStatic(bookmark);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint FPDFAction_GetType_Delegate(FPDF_ACTION action);

        private static FPDFAction_GetType_Delegate FPDFAction_GetTypeStatic { get; set; }

        /// <summary>
        /// Get the type of |action|.
        /// </summary>
        /// <param name="action">Handle to the action.</param>
        /// <returns>Returns one of: PDFACTION_UNSUPPORTED, PDFACTION_GOTO, PDFACTION_REMOTEGOTO, PDFACTION_URI, PDFACTION_LAUNCH.</returns>
        /// <remarks>
        /// FPDF_EXPORT unsigned long FPDF_CALLCONV FPDFAction_GetType(FPDF_ACTION action);.
        /// </remarks>
        public uint FPDFAction_GetType(FPDF_ACTION action)
        {
            lock (_syncObject)
            {
                return FPDFAction_GetTypeStatic(action);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_DEST FPDFAction_GetDest_Delegate(FPDF_DOCUMENT document, FPDF_ACTION action);

        private static FPDFAction_GetDest_Delegate FPDFAction_GetDestStatic { get; set; }

        /// <summary>
        /// Get the destination of |action|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="action">Handle to the action. |action| must be a |PDFACTION_GOTO| or |PDFACTION_REMOTEGOTO|.</param>
        /// <returns>Returns a handle to the destination data, or NULL on error,
        /// typically because the arguments were bad or the action was of the wrong type.</returns>
        /// <remarks>
        /// In the case of |PDFACTION_REMOTEGOTO|, you must first call FPDFAction_GetFilePath(), then load the document at that path,
        /// then pass the document handle from that document as |document| to FPDFAction_GetDest().
        /// FPDF_EXPORT FPDF_DEST FPDF_CALLCONV FPDFAction_GetDest(FPDF_DOCUMENT document, FPDF_ACTION action);.
        /// </remarks>
        public FPDF_DEST FPDFAction_GetDest(FPDF_DOCUMENT document, FPDF_ACTION action)
        {
            lock (_syncObject)
            {
                return FPDFAction_GetDestStatic(document, action);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFAction_GetFilePath_Delegate(FPDF_ACTION action, IntPtr buffer, ulong buflen);

        private static FPDFAction_GetFilePath_Delegate FPDFAction_GetFilePathStatic { get; set; }

        /// <summary>
        /// Get the file path of |action|.
        /// </summary>
        /// <param name="action">Handle to the action. |action| must be a |PDFACTION_LAUNCH| or |PDFACTION_REMOTEGOTO|.</param>
        /// <param name="buffer">A buffer for output the path string. May be NULL.</param>
        /// <param name="buflen">The length of the buffer, in bytes. May be 0.</param>
        /// <returns>Returns the number of bytes in the file path, including the trailing NUL character, or 0 on error,
        /// typically because the arguments were bad or the action was of the wrong type.</returns>
        /// <remarks>
        /// Regardless of the platform, the |buffer| is always in UTF-8 encoding.
        /// If |buflen| is less than the returned length, or |buffer| is NULL, |buffer| will not be modified.
        /// FPDF_EXPORT unsigned long FPDF_CALLCONV FPDFAction_GetFilePath(FPDF_ACTION action, void* buffer, unsigned long buflen);.
        /// </remarks>
        public int FPDFAction_GetFilePath(FPDF_ACTION action, IntPtr buffer, ulong buflen)
        {
            lock (_syncObject)
            {
                return FPDFAction_GetFilePathStatic(action, buffer, buflen);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFAction_GetURIPath_Delegate(FPDF_DOCUMENT document, FPDF_ACTION action, IntPtr buffer, ulong buflen);

        private static FPDFAction_GetURIPath_Delegate FPDFAction_GetURIPathStatic { get; set; }

        /// <summary>
        /// Get the URI path of |action|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="action">Handle to the action. Must be a |PDFACTION_URI|.</param>
        /// <param name="buffer">A buffer for the path string. May be NULL.</param>
        /// <param name="buflen">The length of the buffer, in bytes. May be 0.</param>
        /// <returns>Returns the number of bytes in the URI path, including the trailing NUL character, or 0 on error,
        /// typically because the arguments were bad or the action was of the wrong type.</returns>
        /// <remarks>
        /// The |buffer| may contain badly encoded data. The caller should validate the output. e.g. Check to see if it is UTF-8.
        /// If |buflen| is less than the returned length, or |buffer| is NULL, |buffer| will not be modified.
        /// Historically, the documentation for this API claimed |buffer| is always
        /// encoded in 7-bit ASCII, but did not actually enforce it.
        /// https://pdfium.googlesource.com/pdfium.git/+/d609e84cee2e14a18333247485af91df48a40592
        /// added that enforcement, but that did not work well for real world PDFs that
        /// used UTF-8. As of this writing, this API reverted back to its original
        /// behavior prior to commit d609e84cee.
        /// FPDF_EXPORT unsigned long FPDF_CALLCONV FPDFAction_GetURIPath(FPDF_DOCUMENT document, FPDF_ACTION action, void* buffer, unsigned long buflen);.
        /// </remarks>
        public int FPDFAction_GetURIPath(FPDF_DOCUMENT document, FPDF_ACTION action, IntPtr buffer, ulong buflen)
        {
            lock (_syncObject)
            {
                return FPDFAction_GetURIPathStatic(document, action, buffer, buflen);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFDest_GetDestPageIndex_Delegate(FPDF_DOCUMENT document, FPDF_DEST dest);

        private static FPDFDest_GetDestPageIndex_Delegate FPDFDest_GetDestPageIndexStatic { get; set; }

        /// <summary>
        /// Get the page index of |dest|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="dest">Handle to the destination.</param>
        /// <returns>Returns the 0-based page index containing |dest|. Returns -1 on error.</returns>
        /// <remarks>
        /// FPDF_EXPORT int FPDF_CALLCONV FPDFDest_GetDestPageIndex(FPDF_DOCUMENT document, FPDF_DEST dest);.
        /// </remarks>
        public int FPDFDest_GetDestPageIndex(FPDF_DOCUMENT document, FPDF_DEST dest)
        {
            lock (_syncObject)
            {
                return FPDFDest_GetDestPageIndexStatic(document, dest);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ulong FPDFDest_GetView_Delegate(FPDF_DEST dest, ref ulong pNumParams, IntPtr pParams);

        private static FPDFDest_GetView_Delegate FPDFDest_GetViewStatic { get; set; }

        /// <summary>
        /// Experimental API.
        /// Get the view (fit type) specified by |dest|.
        /// </summary>
        /// <param name="dest">Handle to the destination.</param>
        /// <param name="pNumParams">Receives the number of view parameters, which is at most 4.</param>
        /// <param name="pParams">Buffer to write the view parameters. Must be at least 4 FS_FLOATs long.</param>
        /// <returns>Returns one of the PDFDEST_VIEW_* constants, PDFDEST_VIEW_UNKNOWN_MODE if |dest| does not specify a view.</returns>
        /// <remarks>
        /// FPDF_EXPORT unsigned long FPDF_CALLCONV FPDFDest_GetView(FPDF_DEST dest, unsigned long* pNumParams, FS_FLOAT* pParams);.
        /// </remarks>
        public ulong FPDFDest_GetView(FPDF_DEST dest, ref ulong pNumParams, IntPtr pParams)
        {
            lock (_syncObject)
            {
                return FPDFDest_GetViewStatic(dest, ref pNumParams, pParams);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool FPDFDest_GetLocationInPage_Delegate(FPDF_DEST dest, out bool hasXVal, out bool hasYVal, out bool hasZoomVal, out float x, out float y, out float zoom);

        private static FPDFDest_GetLocationInPage_Delegate FPDFDest_GetLocationInPageStatic { get; set; }

        /// <summary>
        /// Get the (x, y, zoom) location of |dest| in the destination page, if the destination is in [page /XYZ x y zoom] syntax.
        /// </summary>
        /// <param name="dest">Handle to the destination.</param>
        /// <param name="hasXVal">Out parameter; true if the x value is not null.</param>
        /// <param name="hasYVal">Out parameter; true if the y value is not null.</param>
        /// <param name="hasZoomVal">Out parameter; true if the zoom value is not null.</param>
        /// <param name="x">Out parameter; the x coordinate, in page coordinates.</param>
        /// <param name="y">Out parameter; the y coordinate, in page coordinates.</param>
        /// <param name="zoom">Out parameter; the zoom value.</param>
        /// <returns>Returns TRUE on successfully reading the /XYZ value.</returns>
        /// <remarks>
        /// Note the [x, y, zoom] values are only set if the corresponding hasXVal, hasYVal or hasZoomVal flags are true.
        /// FPDF_EXPORT FPDF_BOOL FPDF_CALLCONV FPDFDest_GetLocationInPage(FPDF_DEST dest, FPDF_BOOL* hasXVal, FPDF_BOOL* hasYVal, FPDF_BOOL* hasZoomVal, FS_FLOAT* x, FS_FLOAT* y, FS_FLOAT* zoom);.
        /// </remarks>
        public bool FPDFDest_GetLocationInPage(FPDF_DEST dest, out bool hasXVal, out bool hasYVal, out bool hasZoomVal, out float x, out float y, out float zoom)
        {
            lock (_syncObject)
            {
                return FPDFDest_GetLocationInPageStatic(dest, out hasXVal, out hasYVal, out hasZoomVal, out x, out y, out zoom);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_LINK FPDFLink_GetLinkAtPoint_Delegate(FPDF_PAGE page, double x, double y);

        private static FPDFLink_GetLinkAtPoint_Delegate FPDFLink_GetLinkAtPointStatic { get; set; }

        /// <summary>
        /// Find a link at point (|x|,|y|) on |page|.
        /// </summary>
        /// <param name="page">Handle to the document page.</param>
        /// <param name="x">The x coordinate, in the page coordinate system.</param>
        /// <param name="y">The y coordinate, in the page coordinate system.</param>
        /// <returns>Returns a handle to the link, or NULL if no link found at the given point.</returns>
        /// <remarks>
        /// You can convert coordinates from screen coordinates to page coordinates using FPDF_DeviceToPage().
        /// FPDF_EXPORT FPDF_LINK FPDF_CALLCONV FPDFLink_GetLinkAtPoint(FPDF_PAGE page, double x, double y);.
        /// </remarks>
        public FPDF_LINK FPDFLink_GetLinkAtPoint(FPDF_PAGE page, double x, double y)
        {
            lock (_syncObject)
            {
                return FPDFLink_GetLinkAtPointStatic(page, x, y);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFLink_GetLinkZOrderAtPoint_Delegate(FPDF_PAGE page, double x, double y);

        private static FPDFLink_GetLinkZOrderAtPoint_Delegate FPDFLink_GetLinkZOrderAtPointStatic { get; set; }

        /// <summary>
        /// Find the Z-order of link at point (|x|,|y|) on |page|.
        /// </summary>
        /// <param name="page">Handle to the document page.</param>
        /// <param name="x">The x coordinate, in the page coordinate system.</param>
        /// <param name="y">The y coordinate, in the page coordinate system.</param>
        /// <returns>Returns the Z-order of the link, or -1 if no link found at the given point.
        /// Larger Z-order numbers are closer to the front.</returns>
        /// <remarks>
        /// You can convert coordinates from screen coordinates to page coordinates using FPDF_DeviceToPage().
        /// FPDF_EXPORT int FPDF_CALLCONV FPDFLink_GetLinkZOrderAtPoint(FPDF_PAGE page, double x, double y);.
        /// </remarks>
        public int FPDFLink_GetLinkZOrderAtPoint(FPDF_PAGE page, double x, double y)
        {
            lock (_syncObject)
            {
                return FPDFLink_GetLinkZOrderAtPointStatic(page, x, y);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_DEST FPDFLink_GetDest_Delegate(FPDF_DOCUMENT document, FPDF_LINK link);

        private static FPDFLink_GetDest_Delegate FPDFLink_GetDestStatic { get; set; }

        /// <summary>
        /// Get destination info for |link|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="link">Handle to the link.</param>
        /// <returns>Returns a handle to the destination, or NULL if there is no destination associated with the link.
        /// In this case, you should call FPDFLink_GetAction() to retrieve the action associated with |link|.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_DEST FPDF_CALLCONV FPDFLink_GetDest(FPDF_DOCUMENT document, FPDF_LINK link);.
        /// </remarks>
        public FPDF_DEST FPDFLink_GetDest(FPDF_DOCUMENT document, FPDF_LINK link)
        {
            lock (_syncObject)
            {
                return FPDFLink_GetDestStatic(document, link);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_ACTION FPDFLink_GetAction_Delegate(FPDF_LINK link);

        private static FPDFLink_GetAction_Delegate FPDFLink_GetActionStatic { get; set; }

        /// <summary>
        /// Get action info for |link|.
        /// </summary>
        /// <param name="link">Handle to the link.</param>
        /// <returns>Returns a handle to the action associated to |link|, or NULL if no action.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_ACTION FPDF_CALLCONV FPDFLink_GetAction(FPDF_LINK link);.
        /// </remarks>
        public FPDF_ACTION FPDFLink_GetAction(FPDF_LINK link)
        {
            lock (_syncObject)
            {
                return FPDFLink_GetActionStatic(link);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool FPDFLink_Enumerate_Delegate(FPDF_PAGE page, ref int start_pos, ref FPDF_LINK link_annot);

        private static FPDFLink_Enumerate_Delegate FPDFLink_EnumerateStatic { get; set; }

        /// <summary>
        /// Enumerates all the link annotations in |page|.
        /// </summary>
        /// <param name="page">Handle to the page.</param>
        /// <param name="start_pos">The start position, should initially be 0 and is updated with the next start position on return.</param>
        /// <param name="link_annot">The link handle for |startPos|.</param>
        /// <returns>Returns TRUE on success.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_BOOL FPDF_CALLCONV FPDFLink_Enumerate(FPDF_PAGE page, int* start_pos, FPDF_LINK* link_annot);.
        /// </remarks>
        public bool FPDFLink_Enumerate(FPDF_PAGE page, ref int start_pos, ref FPDF_LINK link_annot)
        {
            lock (_syncObject)
            {
                return FPDFLink_EnumerateStatic(page, ref start_pos, ref link_annot);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_ANNOTATION FPDFLink_GetAnnot_Delegate(FPDF_PAGE page, FPDF_LINK link_annot);

        private static FPDFLink_GetAnnot_Delegate FPDFLink_GetAnnotStatic { get; set; }

        /// <summary>
        /// Gets FPDF_ANNOTATION object for |link_annot|. Experimental API.
        /// </summary>
        /// <param name="page">Handle to the page in which FPDF_LINK object is present.</param>
        /// <param name="link_annot">Handle to link annotation.</param>
        /// <returns>Returns FPDF_ANNOTATION from the FPDF_LINK and NULL on failure, if the input link annot or page is NULL.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_ANNOTATION FPDF_CALLCONV FPDFLink_GetAnnot(FPDF_PAGE page, FPDF_LINK link_annot);.
        /// </remarks>
        public FPDF_ANNOTATION FPDFLink_GetAnnot(FPDF_PAGE page, FPDF_LINK link_annot)
        {
            lock (_syncObject)
            {
                return FPDFLink_GetAnnotStatic(page, link_annot);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool FPDFLink_GetAnnotRect_Delegate(FPDF_LINK link_annot, ref FS_RECTF rect);

        private static FPDFLink_GetAnnotRect_Delegate FPDFLink_GetAnnotRectStatic { get; set; }

        /// <summary>
        /// Get the rectangle for |link_annot|.
        /// </summary>
        /// <param name="link_annot">Handle to the link annotation.</param>
        /// <param name="rect">The annotation rectangle.</param>
        /// <returns>Returns true on success.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_BOOL FPDF_CALLCONV FPDFLink_GetAnnotRect(FPDF_LINK link_annot, FS_RECTF* rect);.
        /// </remarks>
        public bool FPDFLink_GetAnnotRect(FPDF_LINK link_annot, ref FS_RECTF rect)
        {
            lock (_syncObject)
            {
                return FPDFLink_GetAnnotRectStatic(link_annot, ref rect);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFLink_CountQuadPoints_Delegate(FPDF_LINK link_annot);

        private static FPDFLink_CountQuadPoints_Delegate FPDFLink_CountQuadPointsStatic { get; set; }

        /// <summary>
        /// Get the count of quadrilateral points to the |link_annot|.
        /// </summary>
        /// <param name="link_annot">Handle to the link annotation.</param>
        /// <returns>Returns the count of quadrilateral points.</returns>
        /// <remarks>
        /// FPDF_EXPORT int FPDF_CALLCONV FPDFLink_CountQuadPoints(FPDF_LINK link_annot);.
        /// </remarks>
        public int FPDFLink_CountQuadPoints(FPDF_LINK link_annot)
        {
            lock (_syncObject)
            {
                return FPDFLink_CountQuadPointsStatic(link_annot);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool FPDFLink_GetQuadPoints_Delegate(FPDF_LINK link_annot, int quad_index, ref FS_QUADPOINTSF quad_points);

        private static FPDFLink_GetQuadPoints_Delegate FPDFLink_GetQuadPointsStatic { get; set; }

        /// <summary>
        /// Get the quadrilateral points for the specified |quad_index| in |link_annot|.
        /// </summary>
        /// <param name="link_annot">Handle to the link annotation.</param>
        /// <param name="quad_index">The specified quad point index.</param>
        /// <param name="quad_points">Receives the quadrilateral points.</param>
        /// <returns>Returns true on success.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_BOOL FPDF_CALLCONV FPDFLink_GetQuadPoints(FPDF_LINK link_annot, int quad_index, FS_QUADPOINTSF* quad_points);.
        /// </remarks>
        public bool FPDFLink_GetQuadPoints(FPDF_LINK link_annot, int quad_index, ref FS_QUADPOINTSF quad_points)
        {
            lock (_syncObject)
            {
                return FPDFLink_GetQuadPointsStatic(link_annot, quad_index, ref quad_points);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FPDF_ACTION FPDF_GetPageAAction_Delegate(FPDF_PAGE page, int aa_type);

        private static FPDF_GetPageAAction_Delegate FPDF_GetPageAActionStatic { get; set; }

        /// <summary>
        /// Experimental API
        /// Gets an additional-action from |page|.
        /// </summary>
        /// <param name="page">Handle to the page, as returned by FPDF_LoadPage().</param>
        /// <param name="aa_type">The type of the page object's addtional-action, defined in public/fpdf_formfill.h.</param>
        /// <returns>Returns the handle to the action data, or NULL if there is no additional-action of type |aa_type|.</returns>
        /// <remarks>
        /// FPDF_EXPORT FPDF_ACTION FPDF_CALLCONV FPDF_GetPageAAction(FPDF_PAGE page, int aa_type);.
        /// </remarks>
        public FPDF_ACTION FPDF_GetPageAAction(FPDF_PAGE page, int aa_type)
        {
            lock (_syncObject)
            {
                return FPDF_GetPageAActionStatic(page, aa_type);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ulong FPDF_GetFileIdentifier_Delegate(FPDF_DOCUMENT document, FPDF_FILEIDTYPE id_type, IntPtr buffer, ulong buflen);

        private static FPDF_GetFileIdentifier_Delegate FPDF_GetFileIdentifierStatic { get; set; }

        /// <summary>
        /// Experimental API.
        /// Get the file identifer defined in the trailer of |document|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="id_type">The file identifier type to retrieve.</param>
        /// <param name="buffer">A buffer for the file identifier. May be NULL.</param>
        /// <param name="buflen">The length of the buffer, in bytes. May be 0.</param>
        /// <returns>Returns the number of bytes in the file identifier, including the NUL terminator.</returns>
        /// <remarks>
        /// The |buffer| is always a byte string. The |buffer| is followed by a NUL terminator.
        /// If |buflen| is less than the returned length, or |buffer| is NULL, |buffer| will not be modified.
        /// FPDF_EXPORT unsigned long FPDF_CALLCONV FPDF_GetFileIdentifier(FPDF_DOCUMENT document, FPDF_FILEIDTYPE id_type, void* buffer, unsigned long buflen);.
        /// </remarks>
        public ulong FPDF_GetFileIdentifier(FPDF_DOCUMENT document, FPDF_FILEIDTYPE id_type, IntPtr buffer, ulong buflen)
        {
            lock (_syncObject)
            {
                return FPDF_GetFileIdentifierStatic(document, id_type, buffer, buflen);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDF_GetMetaText_Delegate(FPDF_DOCUMENT document, [MarshalAs(UnmanagedType.LPStr)] string tag, IntPtr buffer, ulong buflen);

        private static FPDF_GetMetaText_Delegate FPDF_GetMetaTextStatic { get; set; }

        /// <summary>
        /// Get meta-data |tag| content from |document|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="tag">The tag to retrieve. The tag can be one of: Title, Author, Subject, Keywords, Creator, Producer, CreationDate, or ModDate.
        /// For detailed explanations of these tags and their respective values, please refer to PDF Reference 1.6, section 10.2.1, 'Document Information Dictionary'.</param>
        /// <param name="buffer">A buffer for the tag. May be NULL.</param>
        /// <param name="buflen">The length of the buffer, in bytes. May be 0.</param>
        /// <returns>Returns the number of bytes in the tag, including trailing zeros.</returns>
        /// <remarks>
        /// The |buffer| is always encoded in UTF-16LE. The |buffer| is followed by two bytes of zeros indicating the end of the string.
        /// If |buflen| is less than the returned length, or |buffer| is NULL, |buffer| will not be modified.
        /// For linearized files, FPDFAvail_IsFormAvail must be called before this, and it must have returned PDF_FORM_AVAIL or PDF_FORM_NOTEXIST.
        /// Before that, there is no guarantee the metadata has been loaded.
        /// FPDF_EXPORT unsigned long FPDF_CALLCONV FPDF_GetMetaText(FPDF_DOCUMENT document, FPDF_BYTESTRING tag, void* buffer, unsigned long buflen);.
        /// </remarks>
        public int FPDF_GetMetaText(FPDF_DOCUMENT document, [MarshalAs(UnmanagedType.LPStr)] string tag, IntPtr buffer, ulong buflen)
        {
            lock (_syncObject)
            {
                return FPDF_GetMetaTextStatic(document, tag, buffer, buflen);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDF_GetPageLabel_Delegate(FPDF_DOCUMENT document, int page_index, IntPtr buffer, ulong buflen);

        private static FPDF_GetPageLabel_Delegate FPDF_GetPageLabelStatic { get; set; }

        /// <summary>
        /// Get the page label for |page_index| from |document|.
        /// </summary>
        /// <param name="document">Handle to the document.</param>
        /// <param name="page_index">The 0-based index of the page.</param>
        /// <param name="buffer">A buffer for the page label. May be NULL.</param>
        /// <param name="buflen">The length of the buffer, in bytes. May be 0.</param>
        /// <returns>Returns the number of bytes in the page label, including trailing zeros.</returns>
        /// <remarks>
        /// The |buffer| is always encoded in UTF-16LE. The |buffer| is followed by two bytes of zeros indicating the end of the string.
        /// If |buflen| is less than the returned length, or |buffer| is NULL, |buffer| will not be modified.
        /// FPDF_EXPORT unsigned long FPDF_CALLCONV FPDF_GetPageLabel(FPDF_DOCUMENT document, int page_index, void* buffer, unsigned long buflen);.
        /// </remarks>
        public int FPDF_GetPageLabel(FPDF_DOCUMENT document, int page_index, IntPtr buffer, ulong buflen)
        {
            lock (_syncObject)
            {
                return FPDF_GetPageLabelStatic(document, page_index, buffer, buflen);
            }
        }

        private static void LoadDllDocPart()
        {
            FPDFBookmark_GetFirstChildStatic = GetPDFiumFunction<FPDFBookmark_GetFirstChild_Delegate>(nameof(FPDFBookmark_GetFirstChild));
            FPDFBookmark_GetNextSiblingStatic = GetPDFiumFunction<FPDFBookmark_GetNextSibling_Delegate>(nameof(FPDFBookmark_GetNextSibling));
            FPDFBookmark_GetTitleStatic = GetPDFiumFunction<FPDFBookmark_GetTitle_Delegate>(nameof(FPDFBookmark_GetTitle));
            FPDFBookmark_GetCountStatic = GetPDFiumFunction<FPDFBookmark_GetCount_Delegate>(nameof(FPDFBookmark_GetCount));
            FPDFBookmark_FindStatic = GetPDFiumFunction<FPDFBookmark_Find_Delegate>(nameof(FPDFBookmark_Find));
            FPDFBookmark_GetDestStatic = GetPDFiumFunction<FPDFBookmark_GetDest_Delegate>(nameof(FPDFBookmark_GetDest));
            FPDFBookmark_GetActionStatic = GetPDFiumFunction<FPDFBookmark_GetAction_Delegate>(nameof(FPDFBookmark_GetAction));
            FPDFAction_GetTypeStatic = GetPDFiumFunction<FPDFAction_GetType_Delegate>(nameof(FPDFAction_GetType));
            FPDFAction_GetDestStatic = GetPDFiumFunction<FPDFAction_GetDest_Delegate>(nameof(FPDFAction_GetDest));
            FPDFAction_GetFilePathStatic = GetPDFiumFunction<FPDFAction_GetFilePath_Delegate>(nameof(FPDFAction_GetFilePath));
            FPDFAction_GetURIPathStatic = GetPDFiumFunction<FPDFAction_GetURIPath_Delegate>(nameof(FPDFAction_GetURIPath));
            FPDFDest_GetDestPageIndexStatic = GetPDFiumFunction<FPDFDest_GetDestPageIndex_Delegate>(nameof(FPDFDest_GetDestPageIndex));
            FPDFDest_GetViewStatic = GetPDFiumFunction<FPDFDest_GetView_Delegate>(nameof(FPDFDest_GetView));
            FPDFDest_GetLocationInPageStatic = GetPDFiumFunction<FPDFDest_GetLocationInPage_Delegate>(nameof(FPDFDest_GetLocationInPage));
            FPDFLink_GetLinkAtPointStatic = GetPDFiumFunction<FPDFLink_GetLinkAtPoint_Delegate>(nameof(FPDFLink_GetLinkAtPoint));
            FPDFLink_GetLinkZOrderAtPointStatic = GetPDFiumFunction<FPDFLink_GetLinkZOrderAtPoint_Delegate>(nameof(FPDFLink_GetLinkZOrderAtPoint));
            FPDFLink_GetDestStatic = GetPDFiumFunction<FPDFLink_GetDest_Delegate>(nameof(FPDFLink_GetDest));
            FPDFLink_GetActionStatic = GetPDFiumFunction<FPDFLink_GetAction_Delegate>(nameof(FPDFLink_GetAction));
            FPDFLink_EnumerateStatic = GetPDFiumFunction<FPDFLink_Enumerate_Delegate>(nameof(FPDFLink_Enumerate));
            FPDFLink_GetAnnotStatic = GetPDFiumFunction<FPDFLink_GetAnnot_Delegate>(nameof(FPDFLink_GetAnnot));
            FPDFLink_GetAnnotRectStatic = GetPDFiumFunction<FPDFLink_GetAnnotRect_Delegate>(nameof(FPDFLink_GetAnnotRect));
            FPDFLink_CountQuadPointsStatic = GetPDFiumFunction<FPDFLink_CountQuadPoints_Delegate>(nameof(FPDFLink_CountQuadPoints));
            FPDFLink_GetQuadPointsStatic = GetPDFiumFunction<FPDFLink_GetQuadPoints_Delegate>(nameof(FPDFLink_GetQuadPoints));
            FPDF_GetPageAActionStatic = GetPDFiumFunction<FPDF_GetPageAAction_Delegate>(nameof(FPDF_GetPageAAction));
            FPDF_GetFileIdentifierStatic = GetPDFiumFunction<FPDF_GetFileIdentifier_Delegate>(nameof(FPDF_GetFileIdentifier));
            FPDF_GetMetaTextStatic = GetPDFiumFunction<FPDF_GetMetaText_Delegate>(nameof(FPDF_GetMetaText));
            FPDF_GetPageLabelStatic = GetPDFiumFunction<FPDF_GetPageLabel_Delegate>(nameof(FPDF_GetPageLabel));
        }
    }
}
