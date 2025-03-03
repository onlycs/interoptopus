// Automatically generated by Interoptopus.

#pragma warning disable 0105
using System;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.CompilerServices;
using My.Company;
#pragma warning restore 0105

namespace My.Company
{
    public static partial class Interop
    {
        public const string NativeLib = "core_library";

        static Interop()
        {
        }


        [LibraryImport(NativeLib, EntryPoint = "start_server")]
        public static partial void start_server([MarshalAs(UnmanagedType.LPStr)] string server_name);


        /// Destroys the given instance.
        ///
        /// # Safety
        ///
        /// The passed parameter MUST have been created with the corresponding init function;
        /// passing any other value results in undefined behavior.
        [LibraryImport(NativeLib, EntryPoint = "game_engine_destroy")]
        public static partial FFIError game_engine_destroy(ref IntPtr context);


        [LibraryImport(NativeLib, EntryPoint = "game_engine_new")]
        public static partial FFIError game_engine_new(ref IntPtr context);


        [LibraryImport(NativeLib, EntryPoint = "game_engine_place_object")]
        public static partial FFIError game_engine_place_object(IntPtr context, [MarshalAs(UnmanagedType.LPStr)] string name, Vec2 position);


        [LibraryImport(NativeLib, EntryPoint = "game_engine_num_objects")]
        public static partial uint game_engine_num_objects(IntPtr context);


    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Vec2
    {
        public float x;
        public float y;
    }

    [NativeMarshalling(typeof(MarshallerMeta))]
    public partial struct Vec2
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct Unmanaged
        {
            public float x;
            public float y;
        }

        [CustomMarshaller(typeof(Vec2), MarshalMode.Default, typeof(Marshaller))]
        private struct MarshallerMeta { }

        public ref struct Marshaller
        {
            private Vec2 _managed; // Used when converting managed -> unmanaged
            private Unmanaged _unmanaged; // Used when converting unmanaged -> managed

            public Marshaller(Vec2 managed) { _managed = managed; }

            // TODO, we have to fix this marshalling type
            public void FromManaged(Vec2 managed) { _managed = managed; }
            public void FromUnmanaged(Unmanaged unmanaged) { _unmanaged = unmanaged; }

            public unsafe Unmanaged ToUnmanaged()
            {;
                _unmanaged = new Unmanaged();

                _unmanaged.x = _managed.x;
                _unmanaged.y = _managed.y;

                return _unmanaged;
            }

            public unsafe Vec2 ToManaged() => new Vec2();
            public void Free() { }
        }
    }

    public enum FFIError
    {
        Ok = 0,
        Null = 100,
        Panic = 200,
        Delegate = 300,
        Fail = 400,
    }


    public partial class GameEngine : IDisposable
    {
        private IntPtr _context;

        private GameEngine() {}

        public static GameEngine New()
        {
            var self = new GameEngine();
            var rval = Interop.game_engine_new(ref self._context);
            if (rval != FFIError.Ok)
            {
                throw new InteropException<FFIError>(rval);
            }
            return self;
        }

        public void Dispose()
        {
            var rval = Interop.game_engine_destroy(ref _context);
            if (rval != FFIError.Ok)
            {
                throw new InteropException<FFIError>(rval);
            }
        }

        public void PlaceObject([MarshalAs(UnmanagedType.LPStr)] string name, Vec2 position)
        {
            var rval = Interop.game_engine_place_object(_context, name, position);
            if (rval != FFIError.Ok)
            {
                throw new InteropException<FFIError>(rval);
            }
        }

        public uint NumObjects()
        {
            return Interop.game_engine_num_objects(_context);
        }

        public IntPtr Context => _context;
    }



    public class InteropException<T> : Exception
    {
        public T Error { get; private set; }

        public InteropException(T error): base($"Something went wrong: {error}")
        {
            Error = error;
        }
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void AsyncHelperNative(IntPtr data, IntPtr callback_data);
    public delegate void AsyncHelperDelegate(IntPtr data);

    [NativeMarshalling(typeof(MarshallerMeta))]
    public struct AsyncHelper : IDisposable
    {
        private AsyncHelperDelegate _callbackUser;
        private IntPtr _callbackNative;

        public AsyncHelper() { }

        public AsyncHelper(AsyncHelperDelegate callbackUser)
        {
            _callbackUser = callbackUser;
            _callbackNative = Marshal.GetFunctionPointerForDelegate(new AsyncHelperNative(Call));
        }

        public void Call(IntPtr data, IntPtr callback_data)
        {
            _callbackUser(data);
        }

        public void Dispose()
        {
            if (_callbackNative == IntPtr.Zero) return;
            Marshal.FreeHGlobal(_callbackNative);
            _callbackNative = IntPtr.Zero;
        }

        [CustomMarshaller(typeof(AsyncHelper), MarshalMode.Default, typeof(Marshaller))]
        private struct MarshallerMeta { }

        [StructLayout(LayoutKind.Sequential)]
        public struct Unmanaged
        {
            internal IntPtr Callback;
            internal IntPtr Data;
        }

        public ref struct Marshaller
        {
            private AsyncHelper managed;
            private Unmanaged native;
            private Unmanaged sourceNative;
            private GCHandle? pinned;

            public void FromManaged(AsyncHelper managed)
            {
                this.managed = managed;
            }

            public Unmanaged ToUnmanaged()
            {
                return new Unmanaged
                {
                    Callback = managed._callbackNative,
                    Data = IntPtr.Zero
                };
            }

            public void FromUnmanaged(Unmanaged unmanaged)
            {
                sourceNative = unmanaged;
            }

            public AsyncHelper ToManaged()
            {
                return new AsyncHelper
                {
                    _callbackNative = sourceNative.Callback,
                };
            }

            public void Free() { }
        }
    }
}
