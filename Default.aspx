<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="devoir_3.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Simple Register</title>
        <style type="text/css">
            #btnClear {
                width: 107px;
            }
        </style>

        <!-- CSS only -->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
        <link href="DefaultStyle.css"  rel="stylesheet" />

    </head>

    <body style="height: 507px">
        <form id="form1" runat="server">

            <div class="title_container">
                <asp:Label ID="lblTitle" runat="server" Text="Simple Register"></asp:Label>
            </div>

            <div class="container1">
                <div>
                    <asp:TextBox ID="txtNom"  class="form-control" placeholder="Nom" runat="server" Width="150px" Height="30px" TabIndex="1"></asp:TextBox>
                </div>

                <div>
                    <asp:TextBox ID="txtAdresseRue" class="form-control" placeholder="Adresse" runat="server" TabIndex="5" Width="150px" Height="30px" ></asp:TextBox>
                </div>
            </div>


            <div class="container2">
                 <div>
                     <asp:TextBox ID="txtPrenom1" class="form-control" placeholder="Prenom1" Width="150px" Height="30px" runat="server" TabIndex="2" ></asp:TextBox>
                </div>

                <div>
                     <asp:TextBox ID="txtVille" class="form-control" placeholder="Ville" Width="150px" Height="30px" runat="server" TabIndex="6" ></asp:TextBox>
                </div>
            </div>

            <div class="container3">
                  <div>
                        <asp:TextBox ID="txtPrenom2" class="form-control" placeholder="Prenom2" Width="150px" Height="30px" runat="server" TabIndex="2" ></asp:TextBox>
                  </div>

                <div>
                    <asp:TextBox ID="txtPays" class="form-control" placeholder="Pays" Width="150px" Height="30px" runat="server" TabIndex="7" ></asp:TextBox>
                </div>
            </div>

            <div class="container4">
                  <div>
                        <asp:TextBox ID="txtAge" class="form-control" placeholder="Age" Width="150px" Height="30px" runat="server" TabIndex="3" TextMode="Number"></asp:TextBox>
                  </div>

                <div>
                    <asp:TextBox ID="txtTelephone" class="form-control" placeholder="Telephone" Width="150px" Height="30px" runat="server" TabIndex="8" ></asp:TextBox>
                </div>
            </div>

            <div class="container5">
                  <div>
                    <asp:TextBox ID="txtNationalite" class="form-control" placeholder="Nationalite" Width="150px" Height="30px" runat="server" TabIndex="4" ></asp:TextBox>
                  </div>
            </div>

             <div class="message">
                    <asp:Label ID="lblMessage" runat="server" Text="Message" Visible="False"></asp:Label>
             </div>

            <div class="container6">
                  <div>
                       <asp:Button class="btn btn-primary" ID="btnSauvegarder" runat="server" OnClick="btnSauvegarder_Click" TabIndex="9" Text="Sauvegarder" />
                  </div>

                <div>
                     <asp:Button class="btn btn-secondary" ID="btnAnnuler" runat="server" OnClick="btnAnnuler_Click" TabIndex="10" Text="Annuler" Width="107px" />
                </div>
           </div>

            <div  class="container7">
                <asp:GridView ID="gvPersonne" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="956px" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
            
        </form>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    </body>

</html>
