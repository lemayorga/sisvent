import React from 'react';
import { Form, Input, Button, Checkbox } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
 


import {
  useHistory,
  useLocation
} from "react-router-dom";
import fakeAuth  from '../../utils/fakeAuth';

const Login = (props) => {
    
  let history = useHistory();
  let location = useLocation();

  let { from } = location.state || { from: { pathname: "/" } };



  const onFinish = (values) => {
    
    console.log('Received values of form: ', values);
    fakeAuth.authenticate(() => {
      history.replace(from);
    });
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
        name="username"
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
        <Form.Item name="remember" valuePropName="checked" noStyle>
          <Checkbox>Recordar</Checkbox>
        </Form.Item>

        <a className="login-form-forgot" href="">
          Olvido su contraseña
        </a>
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
