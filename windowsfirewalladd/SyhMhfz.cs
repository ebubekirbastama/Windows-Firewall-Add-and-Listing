using DevComponents.DotNetBar.Controls;
using NetFwTypeLib;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace windowsfirewalladd
{
    public class SyhMhfz
    {
        public static void getroles(DataGridView dataGridView1)
        {
            try
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                dynamic fwPolicy2 = Activator.CreateInstance(tNetFwPolicy2) as dynamic;
                IEnumerable Rules = fwPolicy2.Rules as IEnumerable;
                foreach (dynamic rule in Rules)
                {

                    dataGridView1.Rows.Add(
                       rule.name,
                       rule.ApplicationName,
                       rule.Description,
                       rule.Direction,
                       rule.EdgeTraversal,
                       rule.EdgeTraversalOptions,
                       rule.Enabled,
                       rule.Grouping,
                       rule.IcmpTypesAndCodes,
                       rule.Interfaces,
                       rule.InterfaceTypes,
                       rule.LocalAddresses,
                       rule.LocalAppPackageId,
                       rule.LocalPorts,
                       rule.LocalUserAuthorizedList,
                       rule.LocalUserOwner,
                       rule.Profiles,
                       rule.Protocol,
                       rule.RemoteAddresses,
                       rule.RemoteMachineAuthorizedList,
                       rule.RemotePorts,
                       rule.RemoteUserAuthorizedList,
                       rule.SecureFlags,
                       rule.serviceName,
                       rule.Action
                        );
                    dataGridView1.PerformLayout();

                }
                MessageBox.Show("Bütün Kurallar Çekildi.");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Ebubekir Yazılım.."); }
        }
        public static void baslikcreate(DataGridView dataGridView1)
        {
            dataGridView1.ColumnCount = 25;
            dataGridView1.Columns[0].Name = "name";
            dataGridView1.Columns[1].Name = "ApplicationName";
            dataGridView1.Columns[2].Name = "Description";
            dataGridView1.Columns[3].Name = "Direction";
            dataGridView1.Columns[4].Name = "EdgeTraversal";
            dataGridView1.Columns[5].Name = "EdgeTraversalOptions";
            dataGridView1.Columns[6].Name = "Enabled";
            dataGridView1.Columns[7].Name = "Grouping";
            dataGridView1.Columns[8].Name = "IcmpTypesAndCodes";
            dataGridView1.Columns[9].Name = "Interfaces";
            dataGridView1.Columns[10].Name = "InterfaceTypes";
            dataGridView1.Columns[11].Name = "LocalAddresses";
            dataGridView1.Columns[12].Name = "LocalAppPackageId";
            dataGridView1.Columns[13].Name = "LocalPorts";
            dataGridView1.Columns[14].Name = "LocalUserAuthorizedList";
            dataGridView1.Columns[15].Name = "LocalUserOwner";
            dataGridView1.Columns[16].Name = "Profiles";
            dataGridView1.Columns[17].Name = "Protocol";
            dataGridView1.Columns[18].Name = "RemoteAddresses";
            dataGridView1.Columns[19].Name = "RemoteMachineAuthorizedList";
            dataGridView1.Columns[20].Name = "RemotePorts";
            dataGridView1.Columns[21].Name = "RemoteUserAuthorizedList";
            dataGridView1.Columns[22].Name = "SecureFlags";
            dataGridView1.Columns[23].Name = "serviceName";
            dataGridView1.Columns[24].Name = "Action";
        }
        public static void setroles(TextBoxX textBoxX1, TextBoxX textBoxX2, TextBoxX textBoxX3, RichTextBox richTextBox1)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;
            INetFwRule firewallRule = fwPolicy2.Rules.OfType<INetFwRule>().Where(
                x => x.Name == textBoxX2.Text)
                .FirstOrDefault(); // Koymak istediğiniz kural ile kayıtlı kayıt var mı diye kontrol ediyoruz
            if (firewallRule == null)
            {
                INetFwRule2 inboundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                inboundRule.Enabled = true;
                inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                inboundRule.Protocol = 6; // TCP Protokol Numarası
                inboundRule.LocalPorts = textBoxX1.Text; // Açmak istediğiniz port
                inboundRule.Name = textBoxX2.Text; // Kural ismi
                inboundRule.ApplicationName = textBoxX3.Text;
                inboundRule.Description = richTextBox1.Text;
                inboundRule.Profiles = currentProfiles;
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Add(inboundRule);
                MessageBox.Show("Kural Başarılı Bir Şekilde Oluşturuldu.");
            }
            else
            {
                MessageBox.Show("Bu Kural Mevcut.");
            }
        }
    }
}
