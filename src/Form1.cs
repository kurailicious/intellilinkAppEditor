using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ClientAppInfoEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                LoadFile(openFileDialog1.FileName);
            }
        }

        public class AppInfo
        {
            private string appFileName;
            private string displayName;
            private string iconFileName;
            private uint supportRegionBits;
            private int appCategory;
            public uint flags;
            private int mobileAppId;
            private uint favoriteRegionBits;
            public uint AppSelectCal;
            private int unused;
            private int supportiAP;
            private int iAPProtocolNo;
            private string protocolName;
            private string aPBundleName0;
            private string aPBundleName1;
            private int supportBT;
            private int serviceNo;
            private string bluetoothUUID;
            private uint tetherInfo;
            private int u14;
            private int u15;
            private int u16;
            private int u17;

            public enum Flags
            {
                AudioOutWithModeChange = 1,
                AudioOutInBackground = 2,
                NeedAuxDisplay = 4,
                ProhibitOnDriving = 8,
                UnknownFlag = 10,
                NeedVehicleData = 20
            }

            public enum TetherInfoFields
            {
                SupportUSB = 1,
                SupportWifi = 2,
                SupportWifiAP = 4,
                NeedServerApp = 8
            }

            public string AppFileName
            {
                get
                {
                    return appFileName;
                }

                set
                {
                    appFileName = value;
                }
            }

            public string DisplayName
            {
                get
                {
                    return displayName;
                }

                set
                {
                    displayName = value;
                }
            }

            public string IconFileName
            {
                get
                {
                    return iconFileName;
                }

                set
                {
                    iconFileName = value;
                }
            }

            public uint SupportRegionBits
            {
                get
                {
                    return supportRegionBits;
                }

                set
                {
                    supportRegionBits = value;
                }
            }

            public int AppCategory
            {
                get
                {
                    return appCategory;
                }

                set
                {
                    appCategory = value;
                }
            }

            private static bool getBit(uint bitfield, uint bit)
            {
                return (bitfield & bit) > 0;
            }

            private static uint setBit(uint bitfield, uint bit, bool enabled)
            {
                return enabled ?
                    (bitfield | bit) :
                    (bitfield & ~bit);
            }

            public bool AudioWithModeChange
            {
                get
                {
                    return getBit(flags, (uint)Flags.AudioOutWithModeChange);
                }
                set
                {
                    flags = setBit(flags, (uint)Flags.AudioOutWithModeChange, value);
                }
            }

            public bool AudioOutInBackground
            {
                get
                {
                    return getBit(flags, (uint)Flags.AudioOutInBackground);
                }
                set
                {
                    flags = setBit(flags, (uint)Flags.AudioOutInBackground, value);
                }
            }

            public bool NeedAuxDisplay
            {
                get
                {
                    return getBit(flags, (uint)Flags.NeedAuxDisplay);
                }
                set
                {
                    flags = setBit(flags, (uint)Flags.NeedAuxDisplay, value);
                }
            }

            public bool ProhibitOnDriving
            {
                get
                {
                    return getBit(flags, (uint)Flags.ProhibitOnDriving);
                }
                set
                {
                    flags = setBit(flags, (uint)Flags.ProhibitOnDriving, value);
                }
            }

            public bool UnknownFlag
            {
                get
                {
                    return getBit(flags, (uint)Flags.UnknownFlag);
                }
                set
                {
                    flags = setBit(flags, (uint)Flags.UnknownFlag, value);
                }
            }

            public bool NeedVehicleData
            {
                get
                {
                    return getBit(flags, (uint)Flags.NeedVehicleData);
                }
                set
                {
                    flags = setBit(flags, (uint)Flags.NeedVehicleData, value);
                }
            }

            public uint Reserved
            {
                get
                {
                    return flags >> 6;
                }
            }

            public int MobileAppId
            {
                get
                {
                    return mobileAppId;
                }

                set
                {
                    mobileAppId = value;
                }
            }

            public uint FavoriteRegionBits
            {
                get
                {
                    return favoriteRegionBits;
                }

                set
                {
                    favoriteRegionBits = value;
                }
            }

            public uint AppSelectCalByte
            {
                get
                {
                    return (AppSelectCal & 0xF);
                }
                set
                {
                    AppSelectCal = ((AppSelectCal >> 5) << 5) | (value & 0xF);
                }
            }

            public uint AppSelectCalBit
            {
                get
                {
                    return ((AppSelectCal >> 4) & 0xF);
                }
            }

            public int SupportiAP
            {
                get
                {
                    return supportiAP;
                }

                set
                {
                    supportiAP = value;
                }
            }

            public int IAPProtocolNo
            {
                get
                {
                    return iAPProtocolNo;
                }

                set
                {
                    iAPProtocolNo = value;
                }
            }

            public string ProtocolName
            {
                get
                {
                    return protocolName;
                }

                set
                {
                    protocolName = value;
                }
            }

            public string APBundleName0
            {
                get
                {
                    return aPBundleName0;
                }

                set
                {
                    aPBundleName0 = value;
                }
            }

            public string APBundleName1
            {
                get
                {
                    return aPBundleName1;
                }

                set
                {
                    aPBundleName1 = value;
                }
            }

            public int ServiceNo
            {
                get
                {
                    return serviceNo;
                }

                set
                {
                    serviceNo = value;
                }
            }
            public int SupportBT
            {
                get
                {
                    return supportBT;
                }

                set
                {
                    supportBT = value;
                }
            }

            public string BluetoothUUID
            {
                get
                {
                    return bluetoothUUID;
                }

                set
                {
                    bluetoothUUID = value;
                }
            }

            public uint TetherInfo
            {
                get
                {
                    return tetherInfo;
                }

                set
                {
                    tetherInfo = value;
                }
            }

            public bool SupportUSB
            {
                get
                {
                    return getBit(TetherInfo, (uint)TetherInfoFields.SupportUSB);
                }
                set
                {
                    TetherInfo = setBit(TetherInfo, (uint)TetherInfoFields.SupportUSB, value);
                }
            }

            public bool SupportWifi
            {
                get
                {
                    return getBit(TetherInfo, (uint)TetherInfoFields.SupportWifi);
                }
                set
                {
                    TetherInfo = setBit(TetherInfo, (uint)TetherInfoFields.SupportWifi, value);
                }
            }

            public bool SupportWifiAP
            {
                get
                {
                    return getBit(TetherInfo, (uint)TetherInfoFields.SupportWifiAP);
                }
                set
                {
                    TetherInfo = setBit(TetherInfo, (uint)TetherInfoFields.SupportWifiAP, value);
                }
            }

            public bool NeedServerApp
            {
                get
                {
                    return getBit(TetherInfo, (uint)TetherInfoFields.NeedServerApp);
                }
                set
                {
                    TetherInfo = setBit(TetherInfo, (uint)TetherInfoFields.NeedServerApp, value);
                }
            }

            public int Unused
            {
                get
                {
                    return unused;
                }

                set
                {
                    unused = value;
                }
            }

            public int U14
            {
                get
                {
                    return u14;
                }

                set
                {
                    u14 = value;
                }
            }

            public int U15
            {
                get
                {
                    return u15;
                }

                set
                {
                    u15 = value;
                }
            }

            public int U16
            {
                get
                {
                    return u16;
                }

                set
                {
                    u16 = value;
                }
            }

            public int U17
            {
                get
                {
                    return u17;
                }

                set
                {
                    u17 = value;
                }
            }

            public void read(BinaryReader reader)
            {
                AppFileName = GetAndVerifyStringLength(reader, 40);
                DisplayName = GetAndVerifyStringLength(reader, 40);
                IconFileName = GetAndVerifyStringLength(reader, 100);
                SupportRegionBits = reader.ReadUInt32();
                AppCategory = reader.ReadInt32();
                flags = reader.ReadUInt32();
                MobileAppId = reader.ReadInt32();
                FavoriteRegionBits = reader.ReadUInt32();
                AppSelectCal = reader.ReadUInt32();
                Unused = reader.ReadInt32();
                SupportiAP = reader.ReadInt32();
                IAPProtocolNo = reader.ReadInt32();
                ProtocolName = GetAndVerifyStringLength(reader, 100);
                APBundleName0 = GetAndVerifyStringLength(reader, 50);
                APBundleName1 = GetAndVerifyStringLength(reader, 50);
                SupportBT = reader.ReadInt32();
                ServiceNo = reader.ReadInt32();
                BluetoothUUID = GetAndVerifyStringLength(reader, 64);
                TetherInfo = reader.ReadUInt32();
                U14 = reader.ReadInt32();
                U15 = reader.ReadInt32();
                U16 = reader.ReadInt32();
                U17 = reader.ReadInt32();
            }

            private static void write(BinaryWriter writer, string text, int maxlength)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(text);

                for (int i = 0; i < maxlength; ++i)
                {
                    if (i < bytes.Length)
                    {
                        writer.Write(bytes[i]);
                    }
                    else
                    {
                        writer.Write((byte)0);
                    }
                }
            }

            public void write(BinaryWriter writer)
            {
                write(writer, AppFileName, 40);
                write(writer, DisplayName, 40);
                write(writer, IconFileName, 100);
                writer.Write(SupportRegionBits);
                writer.Write(AppCategory);
                writer.Write(flags);
                writer.Write(MobileAppId);
                writer.Write(FavoriteRegionBits);
                writer.Write(AppSelectCal);
                writer.Write(Unused);
                writer.Write(SupportiAP);
                writer.Write(IAPProtocolNo);
                write(writer, ProtocolName, 100);
                write(writer, APBundleName0, 50);
                write(writer, APBundleName1, 50);
                writer.Write(SupportBT);
                writer.Write(ServiceNo);
                write(writer, BluetoothUUID, 64);
                writer.Write(TetherInfo);
                writer.Write(U14);
                writer.Write(U15);
                writer.Write(U16);
                writer.Write(U17);
            }
        }

        public static string GetAndVerifyStringLength(BinaryReader reader, int length)
        {
            byte[] bytes = reader.ReadBytes(length);

            // find real string length

            bool terminated = false;
            for (int i = 0; i < bytes.Length; ++i)
            {
                if (bytes[i] == 0x00)
                {
                    terminated = true;
                }

                if (terminated && bytes[i] != 0x00)
                {
                    MessageBox.Show("String length is not equal to expected size! " + i);
                }
            }

            return Encoding.ASCII.GetString(bytes).Trim();
        }

        private BindingList<AppInfo> appInfos = new BindingList<AppInfo>();

        private void LoadFile(string filename)
        {
            BinaryReader reader = new BinaryReader(new FileStream(filename, FileMode.Open));

            int appCount = reader.ReadInt32();
            appInfos.Clear();

            DataTable dt = new DataTable();
            foreach (FieldInfo pInfo in typeof(AppInfo).GetFields())
            {
                dt.Columns.Add(pInfo.Name, pInfo.FieldType);
            }

            for (int i = 0; i < appCount; ++i)
            {
                AppInfo appInfo = new AppInfo();
                appInfo.read(reader);
                appInfos.Add(appInfo);

                object[] fields = new object[typeof(AppInfo).GetFields().Length];
                int j = 0;

                foreach (FieldInfo pInfo in typeof(AppInfo).GetFields())
                {
                    fields[j++] = pInfo.GetValue(appInfo);
                }

                dt.Rows.Add(fields);
            }

            dataGridView1.DataSource = appInfos;

            reader.Close();
        }

        private void WriteFile(string filename)
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(filename, FileMode.Create));

            writer.Write(appInfos.Count);

            for (int i = 0; i < appInfos.Count; ++i)
            {
                appInfos[i].write(writer);
            }

            writer.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WriteFile(saveFileDialog1.FileName);
            }
        }
    }
}