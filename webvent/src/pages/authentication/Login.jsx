import React from 'react';
import { useDispatch  } from 'react-redux';
import { Form, Input, Button, Checkbox, Modal } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import { Logear , LogeoFallido , LogeoExitos } from '../../redux/actions/seguridadAction.js';

import { useHistory, useLocation }  from "react-router-dom";
import fakeAuth  from '../../utils/fakeAuth';

const Login = (props) => {
    
  let history = useHistory();
  let location = useLocation();

  let { from } = location.state || { from: { pathname: "/" } };
  const dispatch = useDispatch();



  // const onFinish = (values) => {  
  //   dispatch(Logear(values,
  //     (response) => {
  //       console.log(response)
        
  //       if(!response.data){
  //         if(response.name == 'Error'){
  //           Modal.error({ title: 'Credenciales incorrectas', content: ''});
  //           return;
  //         }  
  //       }
  //       const modal = Modal.success({ title: 'Credenciales correctas', content: ''});

  //       setTimeout(() => {
  //         modal.destroy();
  //       }, 5 * 1000);
       
  //       fakeAuth.authenticate(() => {
  //         history.replace(from);
  //       });
  //     },
  //   (error) => {
  //       console.log(error)
  //       if(error.response)
  //         Modal.info({ title: error.response.data.mensaje,   content: 'Intente nuevamente.' });
  //       else  
  //         Modal.error({ title: 'Ocurrio un error',   content: error.message });
  //     }
  //   ))
  // };

  const onFinish = (values) => {  
    
  
      Logear(values)
      .then(response => {
        console.log(response)

        if(!response.data){
          if(response.name == 'Error'){
            Modal.error({ title: 'Credenciales incorrectas', content: ''});
            return;
          }  
        }
        const modal = Modal.success({ title: 'Credenciales correctas', content: ''});

        setTimeout(() => {
          modal.destroy();
        }, 5 * 1000);
       
        fakeAuth.authenticate(response.data,() => {
          history.replace(from);
        });
        dispatch(LogeoExitos(response.data))

      }).catch(error =>{
        console.log(error)

       
        if(error.response)
          Modal.info({ title: error.response.data.mensaje,   content: 'Intente nuevamente.' });
        else  
          Modal.error({ title: 'Ocurrio un error',   content: error.message });
        
          dispatch(LogeoFallido())
      })

  };







  return (

    <div  style={{ height: "100vh" }}  className="d-flex justify-content-center align-items-center">
      <div style={{ width: 300 }}>
        <h1 className="text-center">Inciar sesión</h1>

        <Form
      name="normal_login"
      className="login-form"
      initialValues={{
        remember: true,
      }}
      onFinish={onFinish}
    >
      <Form.Item
        name="usuario"
        rules={[
          {
            required: true,
            message: 'Ingrese su usuario!',
          },
        ]}
      >
        <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Usuario" />

      </Form.Item>
      <Form.Item
        name="password"
        rules={[
          {
            required: true,
            message: 'Ingrese su contraseña!',

          },
        ]}
      >
        <Input
          prefix={<LockOutlined className="site-form-item-icon" />}
          type="password"
          placeholder="Contraseña"
        />
      </Form.Item>
      <Form.Item>
        {/* <Form.Item name="" valuePropName="checked" noStyle> */}
        <Form.Item  valuePropName="checked" noStyle>
          <Checkbox>Recordar</Checkbox>
        </Form.Item>
        <a className="login-form-forgot" href="">Olvido su contraseña </a>
      </Form.Item>

      <Form.Item>

        <Button type="primary" htmlType="submit" className="login-form-button" 
       >
          Iniciar sesión
        </Button> &nbsp;&nbsp;
         o <a href="">registrarse!</a>
      </Form.Item>
    </Form>

      </div>
    </div>
  );
} 

export default Login;
