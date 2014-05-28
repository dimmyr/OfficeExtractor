using System;
using System.Collections.Generic;

namespace DocumentServices.Modules.Extractors.OfficeExtractor.CompoundFileStorage
{
    public interface ICompoundFile
    {
        bool ValidationExceptionEnabled { get; }

        /// <summary>
        ///     Return true if this compound file has been loaded from an existing file or stream
        /// </summary>
        bool HasSourceStream { get; }

        /// <summary>
        ///     The entry point object that represents the
        ///     root of the structures tree to get stream data.
        /// </summary>
        ICFStorage RootStorage { get; }

        CFSVersion Version { get; }

        /// <summary>
        ///     Close the Compound File object <see cref="T:OpenMcdf.CompoundFile">CompoundFile</see> and
        ///     free all associated resources (e.g. open file handle and allocated memory).
        ///     <remarks>
        ///         When the <see cref="T:OpenMcdf.CompoundFile.Close()">Close</see> method is called,
        ///         all the associated stream and storage objects are invalidated:
        ///         any operation invoked on them will produce a
        ///         <see cref="T:OpenMcdf.CFDisposedException">CFDisposedException</see>.
        ///     </remarks>
        /// </summary>
        /// <example>
        ///     <code>
        ///     const String FILENAME = "CompoundFile.cfs";
        ///     CompoundFile cf = new CompoundFile(FILENAME);
        /// 
        ///     CFStorage st = cf.RootStorage.GetStorage("MyStorage");
        ///     cf.Close();
        /// 
        ///     try
        ///     {
        ///         byte[] temp = st.GetStream("MyStream").GetData();
        ///         
        ///         // The following line will fail because back-end object has been closed
        ///         Assert.Fail("Stream without media");
        ///     }
        ///     catch (Exception ex)
        ///     {
        ///         Assert.IsTrue(ex is CFDisposedException);
        ///     }
        ///  </code>
        /// </example>
        void Close();

        /// <summary>
        ///     Get a list of all entries with a given name contained in the document.
        /// </summary>
        /// <param name="entryName">Name of entries to retrive</param>
        /// <returns>A list of name-matching entries</returns>
        /// <remarks>
        ///     This function is aimed to speed up entity lookup in
        ///     flat-structure files (only one or little more known entries)
        ///     without the performance penalty related to entities hierarchy constraints.
        ///     There is no implied hierarchy in the returned list.
        /// </remarks>
        IList<ICFItem> GetAllNamedEntries(String entryName);
    }
}