﻿namespace PDFiumDotNET.Wrapper.Bridge
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    // Disable "Member 'xxxx' does not access instance data and can be marked as static."
#pragma warning disable CA1822

    /// <summary>
    /// The class contains all pdfium methods currently supported in this project.
    /// </summary>
    public sealed partial class PDFiumBridge
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFText_GetCharIndexFromTextIndex_Delegate(FPDF_TEXTPAGE text_page, int nTextIndex);

        private static FPDFText_GetCharIndexFromTextIndex_Delegate FPDFText_GetCharIndexFromTextIndexStatic { get; set; }

        /// <summary>
        /// Get the character index in |text_page| internal character list.
        /// </summary>
        /// <param name="text_page">A text page information structure.</param>
        /// <param name="nTextIndex">Index of the text returned from FPDFText_GetText().</param>
        /// <returns>Returns the index of the character in internal character list. -1 for error.</returns>
        /// <remarks>
        /// FPDF_EXPORT int FPDF_CALLCONV FPDFText_GetCharIndexFromTextIndex(FPDF_TEXTPAGE text_page, int nTextIndex);.
        /// </remarks>
        public int FPDFText_GetCharIndexFromTextIndex(FPDF_TEXTPAGE text_page, int nTextIndex)
        {
            lock (_syncObject)
            {
                return FPDFText_GetCharIndexFromTextIndexStatic(text_page, nTextIndex);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int FPDFText_GetTextIndexFromCharIndex_Delegate(FPDF_TEXTPAGE text_page, int nCharIndex);

        private static FPDFText_GetTextIndexFromCharIndex_Delegate FPDFText_GetTextIndexFromCharIndexStatic { get; set; }

        /// <summary>
        /// Get the text index in |text_page| internal character list.
        /// </summary>
        /// <param name="text_page">A text page information structure.</param>
        /// <param name="nCharIndex">Index of the character in internal character list.</param>
        /// <returns>Returns the index of the text returned from FPDFText_GetText(). -1 for error.</returns>
        /// <remarks>
        /// FPDF_EXPORT int FPDF_CALLCONV FPDFText_GetTextIndexFromCharIndex(FPDF_TEXTPAGE text_page, int nCharIndex);.
        /// </remarks>
        public int FPDFText_GetTextIndexFromCharIndex(FPDF_TEXTPAGE text_page, int nCharIndex)
        {
            lock (_syncObject)
            {
                return FPDFText_GetTextIndexFromCharIndexStatic(text_page, nCharIndex);
            }
        }

        private static void LoadDllSearchExPart()
        {
            FPDFText_GetCharIndexFromTextIndexStatic = GetPDFiumFunction<FPDFText_GetCharIndexFromTextIndex_Delegate>(nameof(FPDFText_GetCharIndexFromTextIndex));
            FPDFText_GetTextIndexFromCharIndexStatic = GetPDFiumFunction<FPDFText_GetTextIndexFromCharIndex_Delegate>(nameof(FPDFText_GetTextIndexFromCharIndex));
        }
    }
}
